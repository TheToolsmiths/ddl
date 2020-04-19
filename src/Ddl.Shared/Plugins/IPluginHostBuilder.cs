using Microsoft.Extensions.Configuration;
using TheToolsmiths.Ddl.Parser.Shared;

namespace TheToolsmiths.Ddl.Shared.Plugins
{
    public interface IPluginHostBuilder
    {
        IConfiguration Configuration { get; }

        void RegisterParserProvider<T>()
            where T : class, IRootParserProvider;

        void RegisterParserType<T>()
            where T : class, IParser;
    }
}
