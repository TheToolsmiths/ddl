using Microsoft.Extensions.DependencyInjection;

namespace TheToolsmiths.Ddl.Parser.Packager.Services
{
    public static class PackagerServicesInitializer
    {
        public static IServiceCollection RegisterResolverServices(IServiceCollection services)
        {
            services.AddScoped<IDdlContentUnitCollectionPackager, DdlContentUnitCollectionPackager>();
            services.AddScoped<DdlContentUnitPackager>();
            services.AddScoped<DdlPackager>();

            return services;
        }
    }
}
