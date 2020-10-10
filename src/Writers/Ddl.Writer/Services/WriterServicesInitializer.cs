using Microsoft.Extensions.DependencyInjection;
using TheToolsmiths.Ddl.Writer.Handlers;

namespace TheToolsmiths.Ddl.Writer.Services
{
    public static class WriterServicesInitializer
    {
        public static IServiceCollection RegisterWriterServices(IServiceCollection services)
        {
            services.AddScoped<IDdlPackageWriter, DdlPackageWriter>();
            services.AddScoped<IDdlWriterProvider, DdlWriterProvider>();
            
            services.AddScoped<DdlWriterWorkHandler>();

            return services;
        }
    }
}
