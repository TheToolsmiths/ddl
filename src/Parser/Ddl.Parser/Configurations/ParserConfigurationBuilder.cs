using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Parser.ParserMaps.Builders;

namespace TheToolsmiths.Ddl.Parser.Configurations
{
    public class ParserConfigurationBuilder : IParserConfigurationBuilder
    {
        private readonly ParserMapRegistryBuilder registryBuilder;

        public ParserConfigurationBuilder(ParserMapRegistryBuilder registryBuilder)
        {
            this.registryBuilder = registryBuilder;
        }

        public IParserMapRegistryBuilder RegistryBuilder => this.registryBuilder;

        public void Configure(ConfigurationBuilderContext context)
        {
        }
    }
}
