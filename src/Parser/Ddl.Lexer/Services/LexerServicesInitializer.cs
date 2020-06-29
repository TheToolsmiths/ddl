using Microsoft.Extensions.DependencyInjection;

namespace TheToolsmiths.Ddl.Lexer.Services
{
    public static class LexerServicesInitializer
    {
        public static IServiceCollection RegisterLexerServices(IServiceCollection services)
        {
            services.AddTransient<IDdlLexerFactory, DdlLexerFactory>();

            return services;
        }
    }
}
