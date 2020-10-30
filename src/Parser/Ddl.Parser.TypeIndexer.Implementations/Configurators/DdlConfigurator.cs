using System;
using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Models;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Configurations;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer.Implementations.Configurators
{
    public class DdlConfigurator : IDdlConfigurator
    {
        public void Configure(IDdlConfigurationContext context)
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
            builder.RegisterItemIndexer<EnumDefinitionIndexer>(CommonItemTypes.EnumDefinition);
            builder.RegisterItemIndexer<EnumStructDefinitionIndexer>(CommonItemTypes.EnumStructDefinition);
            builder.RegisterItemIndexer<StructDefinitionIndexer>(CommonItemTypes.StructDefinition);
        }
    }
}
