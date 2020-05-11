using TheToolsmiths.Ddl.Cli.Abstractions.Plugins;
using TheToolsmiths.Ddl.Parser.Implementations.Plugins;

[assembly: PluginStartup(typeof(PluginStartup))]

namespace TheToolsmiths.Ddl.Parser.Implementations.Plugins
{
    public class PluginStartup : IPluginStartup
    {
        public void Configure(IPluginHostBuilder builder)
        {
            builder.RegisterParserProvider<ImplementationsRootParserRegister>();

            builder.RegisterItemParserType<StructDefinitionParser>();
            builder.RegisterItemParserType<EnumDefinitionDisambiguationParser>();
            builder.RegisterItemParserType<EnumStructDefinitionParser>();
            builder.RegisterItemParserType<EnumDefinitionParser>();
            builder.RegisterItemParserType<ImportParser>();

            builder.RegisterScopeParserType<RootScopeParser>();
        }
    }
}
