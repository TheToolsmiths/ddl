using System;

using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Models.EntryTypes;
using TheToolsmiths.Ddl.Parser.Build.BuilderMaps;
using TheToolsmiths.Ddl.Parser.Build.Extensions;

namespace TheToolsmiths.Ddl.Parser.Build.Implementations.Plugins
{
    public class ParserConfigurator : IParserConfigurator
    {
        public void Configure(IParserConfigurationContext context)
        {
            if (context.TryGetBuildConfigurationBuilder(out var builder) == false)
            {
                throw new NotImplementedException();
            }

            RegisterBuilders(builder);
        }

        private static void RegisterBuilders(IBuilderMapRegistryBuilder builder)
        {
            builder.RegisterItemBuilder<EnumDefinitionBuilder>(CommonItemTypes.EnumDefinition);
            builder.RegisterItemBuilder<EnumStructDefinitionBuilder>(CommonItemTypes.EnumStructDefinition);
            builder.RegisterItemBuilder<StructDefinitionBuilder>(CommonItemTypes.StructDefinition);
            builder.RegisterItemBuilder<ImportStatementBuilder>(CommonItemTypes.ImportStatement);

            builder.RegisterScopeBuilder<ConditionalRootScopeBuilder>(CommonScopeTypes.ConditionalScope);
        }
    }
}
