using TheToolsmiths.Ddl.Configurations;

namespace TheToolsmiths.Ddl.Services
{
    public class DdlServicesConfigurationBuilder
    {
        public DdlServicesConfigurationBuilder()
        {
            this.ConfigurationRegistryBuilder = new ConfigurationRegistryBuilder();

            this.ParserConfigurators = new ParserConfiguratorProviderBuilder();

            this.ConfigurationBuilders = new ConfigurationBuilderCollectionBuilder();
        }

        public ConfigurationRegistryBuilder ConfigurationRegistryBuilder { get; }

        public ParserConfiguratorProviderBuilder ParserConfigurators { get; }

        public ConfigurationBuilderCollectionBuilder ConfigurationBuilders { get; }
    }
}
