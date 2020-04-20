using Microsoft.Extensions.DependencyInjection;

namespace TheToolsmiths.Ddl.Lexer.Services
{
    public static class LexerServiceCollectionInitializer
    {
        public static IServiceCollection RegisterLexerServices(this IServiceCollection services)
        {
            services.AddTransient<IDdlLexerFactory, DdlLexerFactory>();

            return services;
        }
    }
}
