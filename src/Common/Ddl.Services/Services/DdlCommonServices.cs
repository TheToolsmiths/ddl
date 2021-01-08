using Microsoft.Extensions.DependencyInjection;

namespace TheToolsmiths.Ddl.Services
{
    public static class DdlCommonServices
    {
        public static void Register(IServiceCollection services)
        {
            var configurationBuilder = new DdlServicesConfigurationBuilder();

            DdlConfigurationBuilders.RegisterConfigurationBuilders(configurationBuilder);

            DdlConfigurationBuilders.BuildAndRegisterConfiguration(configurationBuilder, services);
        }
    }
}
