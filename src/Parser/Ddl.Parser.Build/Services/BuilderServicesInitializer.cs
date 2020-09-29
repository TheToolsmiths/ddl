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

            // Register Common Builders
            services.AddScoped<ScopeContentBuilder>();
            services.AddScoped<AttributeUseBuilder>();
            services.AddScoped<StructDefinitionContentBuilder>();
            services.AddScoped<ConditionalExpressionBuilder>();
            services.AddScoped<ValueInitializationBuilder>();
            services.AddScoped<LiteralValueBuilder>();

            // Root Builders
            services.AddScoped<IAstRootItemBuilder, AstRootItemBuilder>();
            services.AddScoped<IAstRootScopeBuilder, AstRootScopeBuilder>();
            
            services.AddScoped<IAstContentUnitScopeBuilder, AstContentUnitScopeBuilder>();

            return services;
        }
    }
}
