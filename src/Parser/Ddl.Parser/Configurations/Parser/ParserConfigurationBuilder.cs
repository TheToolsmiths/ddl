using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Parser.ParserMaps.Builders;

namespace TheToolsmiths.Ddl.Parser.Configurations.Parser
{
    public class ParserConfigurationBuilder : ConfigurationBuilder, IParserConfigurationBuilder
    {
        private readonly ParserMapRegistryBuilder registryBuilder;

        public ParserConfigurationBuilder(ParserMapRegistryBuilder registryBuilder)
        {
            this.registryBuilder = registryBuilder;
        }

        public IParserMapRegistryBuilder RegistryBuilder => this.registryBuilder;

        public override void Configure(ConfigurationBuilderContext context)
        {
        }
    }
}
