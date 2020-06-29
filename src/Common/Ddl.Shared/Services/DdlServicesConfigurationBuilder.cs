using TheToolsmiths.Ddl.Configurations;

namespace TheToolsmiths.Ddl.Services
{
    public class DdlServicesConfigurationBuilder
    {
        public DdlServicesConfigurationBuilder()
        {
            this.ProviderCollectionBuilder = new ConfigurationProviderCollectionBuilder();

            this.ParserConfigurators = new ParserConfiguratorProviderBuilder();
        }

        public ConfigurationProviderCollectionBuilder ProviderCollectionBuilder { get; }

        public ParserConfiguratorProviderBuilder ParserConfigurators { get; }
    }
}
