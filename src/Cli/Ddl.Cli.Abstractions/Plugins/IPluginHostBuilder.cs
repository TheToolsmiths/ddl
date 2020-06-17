using Microsoft.Extensions.Configuration;

using TheToolsmiths.Ddl.Parser;
using TheToolsmiths.Ddl.Parser.Build;

namespace TheToolsmiths.Ddl.Cli.Abstractions.Plugins
{
    public interface IPluginHostBuilder
    {
        IConfiguration Configuration { get; }

        void RegisterParserProvider<T>()
            where T : class, IRootParserRegister;

        void RegisterBuilderProvider<T>()
            where T : class, IRootBuilderRegister;

        void RegisterItemParserType<T>()
            where T : class, IRootItemParser;

        void RegisterScopeParserType<T>()
            where T : class, IRootScopeParser;

        void RegisterRootItemBuilder<T>()
            where T : class, IRootItemBuilder;

        void RegisterRootScopeBuilder<T>()
            where T : class, IRootScopeBuilder;
    }
}
