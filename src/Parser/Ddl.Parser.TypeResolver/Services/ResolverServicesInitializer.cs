using Microsoft.Extensions.DependencyInjection;

using TheToolsmiths.Ddl.Parser.TypeResolver.Common;
using TheToolsmiths.Ddl.Parser.TypeResolver.TypeResolvers;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.Services
{
    public static class ResolverServicesInitializer
    {
        public static IServiceCollection RegisterResolverServices(IServiceCollection services)
        {
            services.AddScoped<DdlContentUnitTypeResolver>();

            services.AddScoped(RootTypeResolverResolver.CreateResolver);

            services.AddScoped<IDdlContentUnitCollectionTypeResolver, DdlContentUnitCollectionTypeResolver>();

            // Register Common Type Resolvers
            services.AddScoped<ScopeContentTypeResolver>();
            services.AddScoped<AttributesTypeResolver>();
            services.AddScoped<StructDefinitionContentTypeResolver>();
            services.AddScoped<ValueInitializationTypeResolver>();


            services.AddScoped<IRootScopeTypeResolver, RootScopeTypeResolver>();
            services.AddScoped<IRootItemTypeResolver, RootItemTypeResolver>();

            return services;
        }
    }
}
