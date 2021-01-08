using Microsoft.Extensions.DependencyInjection;

namespace TheToolsmiths.Ddl.Configurations
{
    public class ConfigurationBuilderContext
    {
        public ConfigurationBuilderContext(
            IServiceCollection services,
            ConfigurationProviderCollection providerCollection)
        {
            this.Services = services;
            this.ProviderCollection = providerCollection;
        }

        public IServiceCollection Services { get; }

        public ConfigurationProviderCollection ProviderCollection { get; }
    }
}
