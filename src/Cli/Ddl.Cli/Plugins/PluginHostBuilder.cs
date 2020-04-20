using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheToolsmiths.Ddl.Cli.Abstractions.Plugins;
using TheToolsmiths.Ddl.Parser.Shared;

namespace TheToolsmiths.Ddl.Cli.Plugins
{
    internal class PluginHostBuilder : IPluginHostBuilder
    {
        private readonly IServiceCollection services;

        public PluginHostBuilder(IConfiguration configuration, IServiceCollection services)
        {
            this.services = services;
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void RegisterParserProvider<T>()
            where T : class, IRootParserProvider
        {
            this.services.AddTransient<IRootParserProvider, T>();
        }

        public void RegisterParserType<T>()
            where T : class, IParser
        {
            this.services.AddTransient<T>();
        }
    }
}
