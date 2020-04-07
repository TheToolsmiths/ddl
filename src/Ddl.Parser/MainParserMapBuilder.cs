using TheToolsmiths.Ddl.Parser.Containers;
using TheToolsmiths.Ddl.Parser.Parsers;
using TheToolsmiths.Ddl.Parser.Parsers.Implementations;

namespace TheToolsmiths.Ddl.Parser
{
    public static class MainParserMapBuilder
    {
        public static CharSpanKeyedMap<IRootParser> CreateMainParsersMap()
        {
            var definitionsParser = new CategoryRootParser
            {
                { ParserIdentifierConstants.Struct, new StructDefinitionParser() },
                { ParserIdentifierConstants.Enum, new EnumDefinitionDisambiguationParser() }
            };

            return new CharSpanKeyedMap<IRootParser>
            {
                { ParserIdentifierConstants.Definition, definitionsParser },
                { ParserIdentifierConstants.Import, new ImportParser() },
                { ParserIdentifierConstants.Scope, new FileScopeParser() }
            };
        }
    }
}
