using Microsoft.Extensions.DependencyInjection;
using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Lexer.Services;
using TheToolsmiths.Ddl.Parser.Build.Services;
using TheToolsmiths.Ddl.Parser.Services;

namespace TheToolsmiths.Ddl.Services
{
    public class DdlServicesRegister
    {
        private readonly IServiceCollection services;

        public DdlServicesRegister(IServiceCollection services)
        {
            this.services = services;
        }

        public void RegisterServices(
            ParserConfiguratorCollection configurators,
            ConfigurationProviderCollection providerCollection)
        {
            this.RegisterCoreServices();

            this.RegisterPluginServices(configurators, providerCollection);
        }

        private void RegisterCoreServices()
        {
            DdlServicesInitializer.RegisterDdlServices(this.services);

            BuilderServicesInitializer.RegisterBuilderServices(this.services);

            LexerServicesInitializer.RegisterLexerServices(this.services);

            ParserServicesInitializer.RegisterParserServices(this.services);
        }

        private void RegisterPluginServices(
            ParserConfiguratorCollection parserConfigurators,
            ConfigurationProviderCollection providerCollection)
        {
            foreach (var provider in parserConfigurators.Providers)
            {
                var context = new ParserConfiguratorContext(providerCollection);

                provider.Configure(context);
            }

            foreach (var configurationProvider in providerCollection.ConfigurationProviders)
            {
                var configurationContext = new ConfigurationProviderContext(this.services);

                configurationProvider.Configure(configurationContext);
            }
        }
    }
}
