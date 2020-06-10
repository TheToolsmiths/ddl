using Microsoft.Extensions.Configuration;

using TheToolsmiths.Ddl.Parser;
using TheToolsmiths.Ddl.Parser.Build;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Scopes;

namespace TheToolsmiths.Ddl.Cli.Abstractions.Plugins
{
    public interface IPluginHostBuilder
    {
        IConfiguration Configuration { get; }

        void RegisterParserProvider<T>()
            where T : class, IRootParserRegister;

        void RegisterItemParserType<T>()
            where T : class, IRootItemParser;

        void RegisterScopeParserType<T>()
            where T : class, IRootScopeParser;

        void RegisterRootItemBuilder<T, TItem>()
            where T : class, IRootItemBuilder<TItem>
            where TItem : class, IRootItem;

        void RegisterRootScopeBuilder<T, TScope>()
            where T : class, IRootScopeBuilder<TScope>
            where TScope : class, IRootScope;
    }
}
