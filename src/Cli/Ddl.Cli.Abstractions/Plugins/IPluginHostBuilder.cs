using Microsoft.Extensions.Configuration;
using TheToolsmiths.Ddl.Parser;

namespace TheToolsmiths.Ddl.Cli.Abstractions.Plugins
{
    public interface IPluginHostBuilder
    {
        IConfiguration Configuration { get; }

        void RegisterParserProvider<T>()
            where T : class, IRootParserRegister;

        void RegisterParserType<T>()
            where T : class, IParser;
    }
}
