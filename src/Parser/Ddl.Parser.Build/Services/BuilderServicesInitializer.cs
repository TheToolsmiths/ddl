using Microsoft.Extensions.DependencyInjection;

using TheToolsmiths.Ddl.Parser.Build.Builders;
using TheToolsmiths.Ddl.Parser.Build.Common;

namespace TheToolsmiths.Ddl.Parser.Build.Services
{
    public static class BuilderServicesInitializer
    {
        public static IServiceCollection RegisterBuilderServices(IServiceCollection services)
        {
            services.AddScoped<DdlContentUnitBuilder>();

            services.AddScoped<IDdlContentUnitCollectionBuilder, DdlContentUnitCollectionBuilder>();

            services.AddScoped(RootBuilderResolver.CreateResolver);

            services.AddScoped<ScopeContentBuilder>();

            // Root Item Resolvers
            services.AddScoped<RootItemBuilder>();
            services.AddScoped<RootScopeBuilder>();

            services.AddScoped<ICommonBuilders, CommonBuilders>();

            return services;
        }
    }
}
