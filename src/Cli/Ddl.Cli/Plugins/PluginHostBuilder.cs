using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using TheToolsmiths.Ddl.Cli.Abstractions.Plugins;
using TheToolsmiths.Ddl.Parser;
using TheToolsmiths.Ddl.Parser.Build;

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

        public void RegisterBuilderProvider<T>()
            where T : class, IRootBuilderRegister
        {
            this.services.AddTransient<IRootBuilderRegister, T>();
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

        public void RegisterRootItemBuilder<T>()
            where T : class, IRootItemBuilder
        {
            this.services.AddTransient<T>();
        }

        public void RegisterRootScopeBuilder<T>()
            where T : class, IRootScopeBuilder
        {
            this.services.AddTransient<T>();
        }
    }
}
