using System;
using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Models.EntryTypes;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Configurations;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Extensions;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer.Implementations.Configurators
{
    public class ParserConfigurator : IParserConfigurator
    {
        public void Configure(IParserConfigurationContext context)
        {
            if (context.TryGetIndexingConfigurationBuilder(out var builder) == false)
            {
                throw new NotImplementedException();
            }

            this.RegisterIndexers(builder);
        }

        private void RegisterIndexers(IIndexingConfigurationBuilder builder)
        {
            // Register Item Builders
            {
                builder.RegisterItemIndexer<EnumDefinitionIndexer>(CommonItemTypes.EnumDefinition);
                builder.RegisterItemIndexer<EnumStructDefinitionIndexer>(CommonItemTypes.EnumStructDefinition);
                builder.RegisterItemIndexer<StructDefinitionIndexer>(CommonItemTypes.StructDefinition);
            }
        }
    }
}
