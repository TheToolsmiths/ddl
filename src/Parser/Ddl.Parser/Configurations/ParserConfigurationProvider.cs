using Microsoft.Extensions.DependencyInjection;

using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Parser.ParserMaps.Builders;
using TheToolsmiths.Ddl.Parser.Parsers.ParserMaps;

namespace TheToolsmiths.Ddl.Parser.Configurations
{
    public class ParserConfigurationProvider : IConfigurationProvider
    {
        public ParserConfigurationProvider()
        {
            this.RegistryBuilder = new ParserMapRegistryBuilder();
        }

        public ParserMapRegistryBuilder RegistryBuilder { get; }

        public void Configure(ConfigurationProviderContext context)
        {
            var registry = ParserMapRegistryFactory.CreateMap(this.RegistryBuilder);

            context.Services.AddSingleton(registry);

            foreach (var itemParserType in ParserMapRegistryFactory.GetItemParserTypeList(this.RegistryBuilder))
            {
                context.Services.AddTransient(itemParserType);
            }

            foreach (var scopeParserType in ParserMapRegistryFactory.GetScopeParserTypeList(this.RegistryBuilder))
            {
                context.Services.AddTransient(scopeParserType);
            }
        }
    }
}
