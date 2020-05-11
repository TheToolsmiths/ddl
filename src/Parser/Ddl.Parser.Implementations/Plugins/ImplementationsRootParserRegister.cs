namespace TheToolsmiths.Ddl.Parser.Implementations.Plugins
{
    public class ImplementationsRootParserRegister : IRootParserRegister
    {
        public void RegisterParsers(IParserMapRegistryBuilder builder)
        {
            {
                var defParser = builder.AddCategoryParser(ParserIdentifierConstants.Definition);

                defParser.AddItemParser<StructDefinitionParser>(ParserIdentifierConstants.Struct);

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
