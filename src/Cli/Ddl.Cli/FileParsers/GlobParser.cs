using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TheToolsmiths.Ddl.Cli.Utils;
using TheToolsmiths.Ddl.Parser;
using TheToolsmiths.Ddl.Parser.Errors;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits;

namespace TheToolsmiths.Ddl.Cli.FileParsers
{
    internal class GlobParser
    {
        private readonly ILogger<GlobParser> log;
        private readonly IServiceProvider provider;

        public GlobParser(
            ILogger<GlobParser> log,
            IServiceProvider provider)
        {
            this.log = log;
            this.provider = provider;
        }

        public async Task<GlobParseResult> ParseDirectoryGlob(DirectoryInfo rootDirectory, string glob)
        {
            using var _ = this.log.BeginScope("Parsing glob");

            this.log.BeginScope($"Parsing glob '{glob}' of dir '{rootDirectory}'");


            var contents = new List<ContentUnit>();
            var errors = new List<ContentUnitParseError>();

            foreach (var inputFile in FileGlobResolver.ResolveAbsoluteFiles(glob, rootDirectory))
            {
                using var scope = this.provider.CreateScope();

                var fileParser = scope.ServiceProvider.GetService<DdlTextParser>();

                var result = await fileParser.ParseFromFile(inputFile);

                if (result.IsSuccess)
                {
                    contents.Add(result.Content);
                }
                else
                {
                    errors.Add(ContentUnitParseError.FromParseResult(result));
                }
            }

            this.log.LogInformation("Glob parsed");

            return GlobParseResult.FromResults(contents, errors);
        }
    }
}
