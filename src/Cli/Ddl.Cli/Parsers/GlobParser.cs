using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TheToolsmiths.Ddl.Cli.Utils;
using TheToolsmiths.Ddl.Parser;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Cli.Parsers
{
    internal class GlobParser
    {
        private readonly ILogger<GlobParser> log;
        private readonly DdlTextParser textParser;

        public GlobParser(
            ILogger<GlobParser> log,
            DdlTextParser textParser)
        {
            this.log = log;
            this.textParser = textParser;
        }

        public async Task<GlobParseResult> ParseDirectoryGlob(DirectoryInfo rootDirectory, string glob)
        {
            using var _ = this.log.BeginScope("Parsing glob");

            this.log.BeginScope($"Parsing glob '{glob}' of dir '{rootDirectory}'");


            var contents = new List<AstContentUnit>();
            var errors = new List<ResultError>();

            foreach (var inputFile in FileGlobResolver.ResolveAbsoluteFiles(glob, rootDirectory))
            {
                var result = await this.textParser.ParseFromFile(inputFile, rootDirectory);

                if (result.IsSuccess)
                {
                    contents.Add(result.AstContent);
                }
                else
                {
                    errors.Add(ResultError.FromErrorMessage(result.ErrorMessage));
                }
            }

            this.log.LogInformation("Glob parsed");

            return GlobParseResult.FromResults(contents, errors);
        }
    }
}
