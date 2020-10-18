using Microsoft.Extensions.DependencyInjection;
using TheToolsmiths.Ddl.Parser.Compiler.Common;
using TheToolsmiths.Ddl.Parser.Compiler.Compilers;

namespace TheToolsmiths.Ddl.Parser.Compiler.Services
{
    public static class CompilerServicesInitializer
    {
        public static IServiceCollection RegisterResolverServices(IServiceCollection services)
        {
            services.AddScoped<DdlContentUnitCompiler>();

            services.AddScoped(RootItemCompilerResolver.CreateResolver);

            services.AddScoped<IDdlContentUnitCollectionCompiler, DdlContentUnitCollectionCompiler>();

            // Register Common Compilers
            services.AddScoped<ScopeContentCompiler>();
            services.AddScoped<AttributesCompiler>();
            services.AddScoped<StructDefinitionContentCompiler>();
            services.AddScoped<ValueInitializationCompiler>();


            services.AddScoped<IContentUnitCompiler, ContentUnitCompiler>();

            services.AddScoped<IRootScopeCompiler, RootScopeCompiler>();
            services.AddScoped<IRootItemCompiler, RootItemCompiler>();

            return services;
        }
    }
}
