using TheToolsmiths.Ddl.Cli.Abstractions.Plugins;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Build.Implementations.Plugins;

[assembly: PluginStartup(typeof(PluginStartup))]

namespace TheToolsmiths.Ddl.Parser.Build.Implementations.Plugins
{
    public class PluginStartup : IPluginStartup
    {
        public void Configure(IPluginHostBuilder builder)
        {
            builder.RegisterBuilderProvider<ImplementationsBuilderRegister>();

            builder.RegisterRootItemBuilder<EnumDefinitionBuilder>();
            builder.RegisterRootItemBuilder<EnumStructDefinitionBuilder>();
            builder.RegisterRootItemBuilder<StructDefinitionBuilder>();
            builder.RegisterRootItemBuilder<ImportStatementBuilder>();

            builder.RegisterRootScopeBuilder<ConditionalRootScopeBuilder>();
        }
    }
}
