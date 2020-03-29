using System.Collections.Generic;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Contexts;

namespace TheToolsmiths.Ddl.Parser.Parsers.Implementations
{
    internal class EnumParserContext : RootParserContext
    {
        private EnumParserContext(DdlLexer lexer, IReadOnlyList<IAttributeUse> attributeList,
            ContextParsers parsers, LexerToken identifier)
            : base(lexer, attributeList, parsers)
        {
        }

        public static EnumParserContext WithIdentifier(RootParserContext context, LexerToken identifier)
        {
            return new EnumParserContext(context.Lexer, context.AttributeList, context.Parsers, identifier);
        }
    }
}
