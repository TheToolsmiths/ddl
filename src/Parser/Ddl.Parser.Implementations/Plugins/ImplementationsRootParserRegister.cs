namespace TheToolsmiths.Ddl.Parser.Implementations.Plugins
{
    public class ImplementationsRootParserRegister : IRootParserRegister
    {
        public void RegisterParsers(IParserMapRegistryBuilder builder)
        {
            // Add 'def' Parsers
            {
                var defParser = builder.AddCategoryParser(ParserIdentifierConstants.Definition);

                defParser.AddItemParser<StructDefinitionParser>(ParserIdentifierConstants.Struct);

                // Add 'def enum' Parsers
                {
                    var enumParser = defParser.AddCategoryParser(ParserIdentifierConstants.Enum);

                    enumParser.SetDefaultParser<EnumDefinitionParser>();

                    enumParser.AddItemParser<EnumStructDefinitionParser>(ParserIdentifierConstants.Struct);
                }
            }

            builder.AddItemParser<ImportParser>(ParserIdentifierConstants.Import);
            
            builder.AddScopeParser<RootScopeParser>(ParserIdentifierConstants.Scope);
        }
    }
}
