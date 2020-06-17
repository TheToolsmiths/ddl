using Microsoft.Extensions.DependencyInjection;

using TheToolsmiths.Ddl.Parser.Build.Builders;
using TheToolsmiths.Ddl.Parser.Build.Builders.BuilderMaps;

namespace TheToolsmiths.Ddl.Parser.Build.Services
{
    public static class BuilderServicesInitializer
    {
        public static IServiceCollection RegisterBuilderServices(this IServiceCollection services)
        {
            services.AddScoped<DdlContentUnitBuilder>();

            services.AddScoped<IDdlContentUnitCollectionBuilder, DdlContentUnitCollectionBuilder>();

            services.AddScoped<RootBuilderResolver>();

            services.AddSingleton(BuilderMapRegistryFactory.CreateMap);

            services.AddScoped<ScopeContentBuilder>();

            // Root Item Resolvers
            services.AddScoped<RootItemBuilder>();
            services.AddScoped<RootScopeBuilder>();

            return services;
        }
    }
}
