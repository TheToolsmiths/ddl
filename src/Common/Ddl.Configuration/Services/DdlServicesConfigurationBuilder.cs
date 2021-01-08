using TheToolsmiths.Ddl.Configurations;

namespace TheToolsmiths.Ddl.Services
{
    public class DdlServicesConfigurationBuilder
    {
        public DdlServicesConfigurationBuilder()
        {
            this.ConfigurationRegistryBuilder = new ConfigurationRegistryBuilder();

            this.Configurators = new DdlConfiguratorProviderBuilder();

            this.ConfigurationBuilders = new ConfigurationBuilderCollectionBuilder();
        }

        public ConfigurationRegistryBuilder ConfigurationRegistryBuilder { get; }

        public DdlConfiguratorProviderBuilder Configurators { get; }

        public ConfigurationBuilderCollectionBuilder ConfigurationBuilders { get; }
    }
}
