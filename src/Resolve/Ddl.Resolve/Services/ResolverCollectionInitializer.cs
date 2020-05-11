using Microsoft.Extensions.DependencyInjection;
using TheToolsmiths.Ddl.Resolve.FirstPhase;
using TheToolsmiths.Ddl.Resolve.FirstPhase.Namespaces;
using TheToolsmiths.Ddl.Resolve.SecondPhase;

namespace TheToolsmiths.Ddl.Resolve.Services
{
    public static class ResolverCollectionInitializer
    {
        public static IServiceCollection RegisterResolverServices(this IServiceCollection services)
        {
            services.AddScoped<DdlContentUnitResolver>();

            services.AddScoped<IDdlContentUnitCollectionResolver, DdlContentUnitCollectionResolver>();

            services = RegisterFirstPhaseServices(services);

            services = RegisterSecondPhaseServices(services);

            return services;
        }

        private static IServiceCollection RegisterFirstPhaseServices(IServiceCollection services)
        {
            services.AddScoped<FirstPhaseContentUnitResolver>();

            services.AddScoped<FirstPhaseContentUnitTypeIndexer>();

            // Root Item Resolvers
            services.AddScoped<FirstPhase.ContentItems.Resolvers.FirstPhaseRootContentItemResolver>();
            services.AddScoped<FirstPhase.ContentItems.Resolvers.ContentUnitItemResolverProvider>();

            services.AddScoped<FirstPhase.ContentItems.Resolvers.EnumDefinitionResolver>();
            services.AddScoped<FirstPhase.ContentItems.Resolvers.EnumStructDefinitionResolver>();
            services.AddScoped<FirstPhase.ContentItems.Resolvers.StructDefinitionResolver>();
            services.AddScoped<FirstPhase.ContentItems.Resolvers.RootScopeResolver>();
            services.AddScoped<FirstPhase.ContentItems.Resolvers.ImportStatementResolver>();

            services.AddScoped<NamespacePathResolver>();

            return services;
        }

        private static IServiceCollection RegisterSecondPhaseServices(IServiceCollection services)
        {
            services.AddScoped<SecondPhaseContentUnitResolver>();

            services.AddScoped<SecondPhaseContentUnitItemsResolver>();

            // Root Item Resolvers
            services.AddScoped<SecondPhase.ContentItems.Resolvers.SecondPhaseRootContentItemResolver>();
            services.AddScoped<SecondPhase.ContentItems.Resolvers.ContentUnitItemResolverProvider>();
            services.AddScoped<SecondPhase.ContentItems.Resolvers.RootScopeResolver>();

            services.AddScoped<SecondPhase.ContentItems.Resolvers.EnumDefinitionResolver>();
            services.AddScoped<SecondPhase.ContentItems.Resolvers.EnumStructDefinitionResolver>();
            services.AddScoped<SecondPhase.ContentItems.Resolvers.StructDefinitionResolver>();

            services.AddScoped<NamespacePathResolver>();

            return services;
        }
    }
}
