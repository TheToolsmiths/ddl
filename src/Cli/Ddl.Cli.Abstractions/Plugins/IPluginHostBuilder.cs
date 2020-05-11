using Microsoft.Extensions.Configuration;
using TheToolsmiths.Ddl.Parser;

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
    }
}
