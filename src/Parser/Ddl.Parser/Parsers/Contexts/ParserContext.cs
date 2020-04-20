using System;
using Microsoft.Extensions.DependencyInjection;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Parser.Common;
using TheToolsmiths.Ddl.Parser.Contexts;

namespace TheToolsmiths.Ddl.Parser.Parsers.Contexts
{
    internal class ParserContext : IParserContext
    {
        public ParserContext(IServiceProvider provider, ILexer lexer)
        {
            this.Lexer = lexer;
            this.Parsers = ActivatorUtilities.CreateInstance<CommonParsers>(provider, this);
        }

        public ILexer Lexer { get; }

        public ICommonParsers Parsers { get; }
    }
}
