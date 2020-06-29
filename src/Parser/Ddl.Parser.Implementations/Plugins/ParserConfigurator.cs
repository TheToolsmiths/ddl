using System;

using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Parser.Extensions;
using TheToolsmiths.Ddl.Parser.ParserMaps.Builders;

namespace TheToolsmiths.Ddl.Parser.Implementations.Plugins
{
    public class ParserConfigurator : IParserConfigurator
    {
        public void Configure(IParserConfigurationContext context)
        {
            if (context.TryGetParserMapRegistryBuilder(out var builder) == false)
            {
                throw new NotImplementedException();
            }

            RegisterParsers(builder);
        }

        private static void RegisterParsers(IParserMapRegistryBuilder builder)
        {
            // Add 'def' Parsers
            {
                var defParser = builder.AddCategoryParser(ParserIdentifierConstants.Definition);

                defParser.AddItemParser<StructDefinitionParser>(ParserIdentifierConstants.Struct);

                // Add 'def enum' Parsers
                {
                    var enumParser = defParser.AddCategoryParser(ParserIdentifierConstants.Enum);

                    enumParser.SetDefaultItemParser<EnumDefinitionParser>();

                    enumParser.AddItemParser<EnumStructDefinitionParser>(ParserIdentifierConstants.Struct);
                }
            }

            builder.AddItemParser<ImportParser>(ParserIdentifierConstants.Import);

            builder.AddScopeParser<RootScopeParser>(ParserIdentifierConstants.Scope);
        }
    }
}
