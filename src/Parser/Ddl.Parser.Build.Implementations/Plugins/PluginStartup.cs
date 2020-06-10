using TheToolsmiths.Ddl.Cli.Abstractions.Plugins;
using TheToolsmiths.Ddl.Parser.Build.Implementations.Plugins;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Models.Enums;
using TheToolsmiths.Ddl.Parser.Models.Imports;
using TheToolsmiths.Ddl.Parser.Models.Structs;
using EnumDefinition = TheToolsmiths.Ddl.Parser.Models.Enums.EnumDefinition;

[assembly: PluginStartup(typeof(PluginStartup))]

namespace TheToolsmiths.Ddl.Parser.Build.Implementations.Plugins
{
    public class PluginStartup : IPluginStartup
    {
        public void Configure(IPluginHostBuilder builder)
        {
            builder.RegisterRootItemBuilder<EnumDefinitionBuilder, EnumDefinition>();
            builder.RegisterRootItemBuilder<EnumStructDefinitionBuilder, EnumStructDefinition>();
            builder.RegisterRootItemBuilder<StructDefinitionBuilder, StructDefinition>();
            builder.RegisterRootItemBuilder<ImportStatementBuilder, ImportStatement>();

            builder.RegisterRootScopeBuilder<ConditionalRootScopeBuilder, ConditionalRootScope>();
        }
    }
}
