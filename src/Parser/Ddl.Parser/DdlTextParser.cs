using System;
using System.IO;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits;

namespace TheToolsmiths.Ddl.Parser
{
    public class DdlTextParser
    {
        private readonly ILogger<DdlTextParser> log;
        private readonly IServiceProvider serviceProvider;

        public DdlTextParser(ILogger<DdlTextParser> log, IServiceProvider serviceProvider)
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
                var info = rootDirectory != null
                    ? AstContentUnitInfo.CreateFromFileInfo(file, rootDirectory)
                    : AstContentUnitInfo.CreateFromFileInfo(file);

                using var scope = this.serviceProvider.CreateScope();

                var parser = await scope.ServiceProvider.GetRequiredService<DdlParserFactory>()
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
