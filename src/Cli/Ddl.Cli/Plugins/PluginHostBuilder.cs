using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using TheToolsmiths.Ddl.Cli.Abstractions.Plugins;
using TheToolsmiths.Ddl.Parser;
using TheToolsmiths.Ddl.Parser.Build;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Scopes;

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

        public void RegisterRootItemBuilder<T, TItem>()
            where T : class, IRootItemBuilder<TItem>
            where TItem : class, IRootItem
        {
            throw new System.NotImplementedException();
        }

        public void RegisterRootScopeBuilder<T, TScope>()
            where T : class, IRootScopeBuilder<TScope>
            where TScope : class, IRootScope
        {
            throw new System.NotImplementedException();
        }
    }
}
