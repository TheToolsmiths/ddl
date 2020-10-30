using Microsoft.Extensions.DependencyInjection;
using TheToolsmiths.Ddl.Writer.Common.Attributes;
using TheToolsmiths.Ddl.Writer.Common.ConditionalExpressions;
using TheToolsmiths.Ddl.Writer.Common.Items;
using TheToolsmiths.Ddl.Writer.Common.Types;
using TheToolsmiths.Ddl.Writer.Common.Values;
using TheToolsmiths.Ddl.Writer.Handlers;
using TheToolsmiths.Ddl.Writer.Writers;

namespace TheToolsmiths.Ddl.Writer.Services
{
    public static class WriterServicesInitializer
    {
        public static IServiceCollection RegisterWriterServices(IServiceCollection services)
        {
            services.AddScoped<IDdlPackageWriter, DdlPackageWriter>();
            services.AddScoped<IDdlWriterProvider, DdlWriterProvider>();

            services.AddScoped<PackageItemsWriter>();
            services.AddScoped<PackageItemWriter>();
            services.AddScoped<CompiledItemDefinitionWriter>();
            services.AddScoped<CompiledSubItemDefinitionWriter>();

            services.AddScoped<DdlWriterWorkHandler>();

            services.AddScoped(CompiledItemDefinitionWriterResolver.CreateResolver);
            services.AddScoped(CompiledSubItemDefinitionWriterResolver.CreateResolver);

            // Register Common Item Writers
            services.AddScoped<StructDefinitionContentWriter>();

            // Register Common Writers
            services.AddScoped<QualifiedTypeNameWriter>();
            services.AddScoped<TypeNameIdentifierWriter>();
            services.AddScoped<TypeUseWriter>();
            services.AddScoped<ConditionalExpressionsWriter>();
            services.AddScoped<ResolvedTypeUseWriter>();
            services.AddScoped<CompiledValueInitializationWriter>();
            services.AddScoped<LiteralValueWriter>();
            services.AddScoped<TypeNameResolutionWriter>();
            services.AddScoped<QualifiedNamespaceWriter>();
            services.AddScoped<CompiledAttributesWriter>();

            return services;
        }
    }
}
