using TheToolsmiths.Ddl.Configurations;

namespace TheToolsmiths.Ddl.Services
{
    public class DdlServicesConfigurationBuilder
    {
        public DdlServicesConfigurationBuilder()
        {
            this.ConfigurationRegistryBuilder = new ConfigurationRegistryBuilder();

            this.ParserConfigurators = new ParserConfiguratorProviderBuilder();
        }

        public ConfigurationRegistryBuilder ConfigurationRegistryBuilder { get; }

        public ParserConfiguratorProviderBuilder ParserConfigurators { get; }
    }
}
