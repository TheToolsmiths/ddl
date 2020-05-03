using Microsoft.Extensions.DependencyInjection;
using TheToolsmiths.Ddl.Resolve.FirstPhase;
using TheToolsmiths.Ddl.Resolve.FirstPhase.ContentItems.Resolvers;
using TheToolsmiths.Ddl.Resolve.FirstPhase.Namespaces;
using TheToolsmiths.Ddl.Resolve.SecondPhase;

namespace TheToolsmiths.Ddl.Resolve.Services
{
    public static class ResolverCollectionInitializer
    {
        public static IServiceCollection RegisterResolverServices(this IServiceCollection services)
        {
            services.AddScoped<DdlContentUnitsResolver>();

            services = RegisterFirstPhaseServices(services);

            services = RegisterSecondPhaseServices(services);

            return services;
        }

        private static IServiceCollection RegisterFirstPhaseServices(IServiceCollection services)
        {
            services.AddScoped<FirstPhaseContentUnitResolver>();

            services.AddScoped<FirstPhaseContentUnitTypeIndexer>();

            services.AddScoped<FirstPhaseContentUnitCollectionResolver>();

            // Root Item Resolvers
            services.AddScoped<FirstPhaseRootContentItemResolver>();
            services.AddScoped<ContentUnitItemResolverProvider>();

            services.AddScoped<EnumDefinitionResolver>();
            services.AddScoped<EnumStructDefinitionResolver>();
            services.AddScoped<StructDefinitionResolver>();
            services.AddScoped<RootScopeResolver>();
            services.AddScoped<ImportStatementResolver>();

            services.AddScoped<NamespacePathResolver>();

            return services;
        }

        private static IServiceCollection RegisterSecondPhaseServices(IServiceCollection services)
        {
            services.AddScoped<SecondPhaseContentUnitResolver>();

            return services;
        }
    }
}
