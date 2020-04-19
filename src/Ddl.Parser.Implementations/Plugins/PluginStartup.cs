using TheToolsmiths.Ddl.Parser.Implementations.Plugins;
using TheToolsmiths.Ddl.Shared.Plugins;

[assembly: PluginStartup(typeof(PluginStartup))]

namespace TheToolsmiths.Ddl.Parser.Implementations.Plugins
{
    public class PluginStartup : IPluginStartup
    {
        public void Configure(IPluginHostBuilder builder)
        {
            builder.RegisterParserProvider<ImplementationsRootParserProvider>();

            builder.RegisterParserType<StructDefinitionParser>();
            builder.RegisterParserType<EnumDefinitionDisambiguationParser>();
            builder.RegisterParserType<ImportParser>();
            builder.RegisterParserType<FileScopeParser>();
        }
    }
}
