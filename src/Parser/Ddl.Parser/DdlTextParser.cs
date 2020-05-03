using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits;

namespace TheToolsmiths.Ddl.Parser
{
    public class DdlTextParser
    {
        private readonly ILogger<DdlTextParser> log;
        private readonly IServiceProvider serviceProvider;

        public DdlTextParser(
            ILogger<DdlTextParser> log,
            IServiceProvider serviceProvider)
        {
            this.log = log;
            this.serviceProvider = serviceProvider;
        }

        public Task<ContentUnitParseResult> ParseFromString(string contents)
        {
            throw new NotImplementedException();
        }

        public async Task<ContentUnitParseResult> ParseFromFile(FileInfo file, DirectoryInfo? rootDirectory = null)
        {
            try
            {
                string relativePath;

                if (rootDirectory != null)
                {
                    relativePath = Path.GetRelativePath(rootDirectory.FullName, file.FullName);
                }
                else
                {
                    relativePath = file.Name;
                }

                using var scope = this.serviceProvider.CreateScope();

                string id = $"file///:{file.FullName}";
                string name = Path.GetFileNameWithoutExtension(file.Name);
                var info = new ContentUnitInfo(id, name, relativePath, file);

                var parser = await scope.ServiceProvider
                    .GetRequiredService<DdlParserFactory>()
                    .CreateForFile(file.FullName);

                return await parser.ParseContentUnit(info);
            }
            catch (Exception e)
            {
                return ContentUnitParseResult.FromException(e);
            }
        }
    }
}
