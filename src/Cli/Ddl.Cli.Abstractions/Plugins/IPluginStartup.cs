using TheToolsmiths.Ddl.Services;

namespace TheToolsmiths.Ddl.Cli.Abstractions.Plugins
{
    public interface IPluginStartup
    {
        void Configure(DdlServicesConfigurationBuilder builder);
    }
}
