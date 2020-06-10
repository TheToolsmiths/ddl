using Microsoft.Extensions.DependencyInjection;
using TheToolsmiths.Ddl.Parser.Build.BuildPhase;

namespace TheToolsmiths.Ddl.Parser.Build.Services
{
    public static class BuilderServicesInitializer
    {
        public static IServiceCollection RegisterBuilderServices(this IServiceCollection services)
        {
            services.AddScoped<DdlContentUnitBuilder>();

            services.AddScoped<IDdlContentUnitCollectionBuilder, DdlContentUnitCollectionBuilder>();

            services.AddScoped<ScopeContentBuilder>();

            // Root Item Resolvers
            services.AddScoped<RootItemBuilder>();
            services.AddScoped<RootScopeBuilder>();

            return services;
        }
    }
}
