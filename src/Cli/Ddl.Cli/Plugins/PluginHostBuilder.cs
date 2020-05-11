using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheToolsmiths.Ddl.Cli.Abstractions.Plugins;
using TheToolsmiths.Ddl.Parser;

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
            where T : class, IRootParserRegister
        {
            this.services.AddTransient<IRootParserRegister, T>();
        }

        public void RegisterItemParserType<T>()
            where T : class, IRootItemParser
        {
            this.services.AddTransient<T>();
        }

        public void RegisterScopeParserType<T>()
            where T : class, IRootScopeParser
        {
            this.services.AddTransient<T>();
        }
    }
}
