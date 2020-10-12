using Microsoft.Extensions.DependencyInjection;
using TheToolsmiths.Ddl.Writer.Common.Attributes;
using TheToolsmiths.Ddl.Writer.Common.TypeNames;
using TheToolsmiths.Ddl.Writer.Handlers;

namespace TheToolsmiths.Ddl.Writer.Services
{
    public static class WriterServicesInitializer
    {
        public static IServiceCollection RegisterWriterServices(IServiceCollection services)
        {
            services.AddScoped<IDdlPackageWriter, DdlPackageWriter>();
            services.AddScoped<IDdlWriterProvider, DdlWriterProvider>();

            services.AddScoped<PackageItemsWriter>();

            services.AddScoped<DdlWriterWorkHandler>();

            // Register Common Writers
            services.AddScoped<TypeNameWriter>();
            services.AddScoped<TypeNameResolutionWriter>();
            services.AddScoped<NamespaceWriter>();
            services.AddScoped<AttributesWriter>();

            return services;
        }
    }
}
