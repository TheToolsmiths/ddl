using Microsoft.Extensions.DependencyInjection;

namespace TheToolsmiths.Ddl.Configurations
{
    public class ConfigurationProviderContext
    {
        public ConfigurationProviderContext(IServiceCollection services)
        {
            this.Services = services;
        }

        public IServiceCollection Services { get; }
    }
}
