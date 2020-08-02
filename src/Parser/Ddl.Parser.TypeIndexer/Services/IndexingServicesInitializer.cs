using Microsoft.Extensions.DependencyInjection;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Indexers;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Namespaces;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer.Services
{
    public static class IndexingServicesInitializer
    {
        public static IServiceCollection RegisterIndexingServices(IServiceCollection services)
        {
            services.AddScoped<DdlContentUnitIndexer>();

            services.AddScoped<NamespacePathResolver>();
            services.AddScoped<TypeReferenceIndexer>();

            services.AddScoped(RootIndexerResolver.CreateResolver);

            services.AddScoped<IDdlContentUnitCollectionIndexer, DdlContentUnitCollectionIndexer>();

            return services;
        }
    }
}
