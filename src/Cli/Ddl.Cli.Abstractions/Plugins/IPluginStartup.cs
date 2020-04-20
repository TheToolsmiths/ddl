namespace TheToolsmiths.Ddl.Cli.Abstractions.Plugins
{
    public interface IPluginStartup
    {
        void Configure(IPluginHostBuilder builder);
    }
}
