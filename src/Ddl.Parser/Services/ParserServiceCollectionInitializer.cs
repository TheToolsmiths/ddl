using Microsoft.Extensions.DependencyInjection;
using TheToolsmiths.Ddl.Parser.Common;
using TheToolsmiths.Ddl.Parser.Parsers;
using TheToolsmiths.Ddl.Parser.Parsers.Contexts;
using TheToolsmiths.Ddl.Parser.Parsers.ParserMaps;
using TheToolsmiths.Ddl.Parser.Shared;
using TheToolsmiths.Ddl.Parser.Shared.Contexts;

namespace TheToolsmiths.Ddl.Parser.Services
{
    public static class ServiceCollectionInitializer
    {
        public static IServiceCollection RegisterParserServices(this IServiceCollection services)
        {
            services.AddScoped<DdlTextParser>();
            
            services.AddTransient<DdlParserFactory>();

            services.AddScoped<IFileRootContentParser, FileRootContentParser>();

            services.AddScoped<IRootItemParserContextFactory, RootItemParserContextFactory>();

            services.AddScoped<IParserContext, ParserContext>();
            
            services.AddScoped<ICategoryParserFactory, CategoryParserFactory>();

            services.AddSingleton(ParserMapRegistryFactory.CreateMap);


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
