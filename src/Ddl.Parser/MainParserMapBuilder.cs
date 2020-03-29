using TheToolsmiths.Ddl.Parser.Containers;
using TheToolsmiths.Ddl.Parser.Contexts;
using TheToolsmiths.Ddl.Parser.Parsers;
using TheToolsmiths.Ddl.Parser.Parsers.Implementations;

namespace TheToolsmiths.Ddl.Parser
{
    public static class MainParserMapBuilder
    {
        public static CharSpanKeyedMap<IRootParser<RootParserContext>> CreateMainParsersMap()
        {
            var definitionsParser = new DefinitionsParser
            {
                { ParserIdentifierConstants.Struct, new StructDefinitionParser() },
                { ParserIdentifierConstants.Enum, new EnumDefinitionDisambiguationParser() }
            };

            return new CharSpanKeyedMap<IRootParser<RootParserContext>>
            {
                { ParserIdentifierConstants.Definition, definitionsParser },
                { ParserIdentifierConstants.Import, new ImportParser() }
            };
        }
    }
}
