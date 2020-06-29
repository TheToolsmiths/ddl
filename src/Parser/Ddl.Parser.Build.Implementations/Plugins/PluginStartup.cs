using TheToolsmiths.Ddl.Cli.Abstractions.Plugins;
using TheToolsmiths.Ddl.Parser.Build.Configurations;
using TheToolsmiths.Ddl.Parser.Build.Implementations.Plugins;
using TheToolsmiths.Ddl.Services;

[assembly: PluginStartup(typeof(PluginStartup))]

namespace TheToolsmiths.Ddl.Parser.Build.Implementations.Plugins
{
    public class PluginStartup : IPluginStartup
    {
        public void Configure(DdlServicesConfigurationBuilder builder)
        {
            builder.ProviderCollectionBuilder.AddProvider<BuilderConfigurationProvider>();

            builder.ParserConfigurators.AddConfigurator<ParserConfigurator>();
        }
    }
}
