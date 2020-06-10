using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Parser.Parsers.Contexts;

namespace TheToolsmiths.Ddl.Parser
{
    internal class DdlParserFactory
    {
        private readonly IServiceProvider provider;

        public DdlParserFactory(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public async Task<DdlParser> CreateForFile(string path)
        {
            var lexer = await this.provider.GetRequiredService<IDdlLexerFactory>().CreateForFile(path);

            var log = this.provider.GetRequiredService<ILoggerFactory>().CreateLogger<DdlParser>();

            var rootContentParser = this.provider.GetRequiredService<IScopeContentParser>();

            var parserContext = new ParserContext(this.provider, lexer);

            return new DdlParser(log, parserContext, rootContentParser);
        }
    }
}
