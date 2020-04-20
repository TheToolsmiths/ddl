namespace TheToolsmiths.Ddl.Parser.Implementations.Plugins
{
    public class ImplementationsRootParserProvider : IRootParserProvider
    {
        public void RegisterParsers(IParserMapRegistryBuilder builder)
        {
            {
                var defParser = builder.AddCategoryParser(ParserIdentifierConstants.Definition);

                defParser.AddParser<StructDefinitionParser>(ParserIdentifierConstants.Struct);
                defParser.AddParser<EnumDefinitionDisambiguationParser>(ParserIdentifierConstants.Enum);
            }

            builder.AddParser<ImportParser>(ParserIdentifierConstants.Import);
            builder.AddParser<FileScopeParser>(ParserIdentifierConstants.Scope);
        }
    }
}
