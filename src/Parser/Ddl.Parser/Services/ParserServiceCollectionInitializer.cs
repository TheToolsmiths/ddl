using Microsoft.Extensions.DependencyInjection;

using TheToolsmiths.Ddl.Parser.Common;
using TheToolsmiths.Ddl.Parser.Parsers;

namespace TheToolsmiths.Ddl.Parser.Services
{
    public static class ParserServicesInitializer
    {
        public static IServiceCollection RegisterParserServices(IServiceCollection services)
        {
            services.AddScoped<DdlTextParser>();

            services.AddTransient<DdlParserFactory>();

            services.AddScoped<IScopeContentParser, ScopeContentParser>();

            services.AddScoped<IRootItemParserContextFactory, RootItemParserContextFactory>();
            services.AddScoped<IRootScopeParserContextFactory, RootScopeParserContextFactory>();

            services.AddTransient<ICategoryParserFactory, CategoryParserFactory>();

            services.AddScoped<IRootParserResolver, RootParserResolver>();

            // Register common parsers
            services.AddTransient<AttributeUsageParser>();
            services.AddTransient<ConditionalExpressionParser>();
            services.AddTransient<FieldInitializationParser>();
            services.AddTransient<LiteralValueInitializationParser>();
            services.AddTransient<StructDefinitionContentParser>();
            services.AddTransient<StructValueInitializationParser>();
            services.AddTransient<TypeIdentifierParser>();
            services.AddTransient<TypeNameParser>();


            return services;
        }
    }
}
