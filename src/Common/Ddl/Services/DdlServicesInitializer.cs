using Microsoft.Extensions.DependencyInjection;
using TheToolsmiths.Ddl.Configuration;
using TheToolsmiths.Ddl.Configurations;

namespace TheToolsmiths.Ddl.Services
{
    public static class DdlServicesInitializer
    {
        public static IServiceCollection RegisterDdlServices(IServiceCollection services)
        {
            services.AddSingleton<IConfigurationRegistry, ConfigurationRegistry>();

            return services;
        }
    }
}
