using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TheToolsmiths.Ddl.Models.FileContents;
using TheToolsmiths.Ddl.Parser.Shared;

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

        public Task<ParseResult<FileContent>> ParseFromString(string contents)
        {
            throw new NotImplementedException();
        }

        public async Task<ParseResult<FileContent>> ParseFromFile(string path)
        {
            return await this.ExecuteParseFromFile(path).ConfigureAwait(false);
        }

        private async Task<ParseResult<FileContent>> ExecuteParseFromFile(string path)
        {
            try
            {
                using (var scope = this.serviceProvider.CreateScope())
                {
                    var scopeProvider = scope.ServiceProvider;

                    var parser = await scopeProvider
                        .GetRequiredService<DdlParserFactory>()
                        .CreateForFile(path);

                    return await parser.ParseFileContents();
                }
            }
            catch (Exception e)
            {
                return ParseResult.FromException<FileContent>(e);
            }
        }
    }
}
