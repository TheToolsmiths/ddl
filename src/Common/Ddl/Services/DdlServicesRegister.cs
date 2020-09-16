using Microsoft.Extensions.DependencyInjection;

using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Lexer.Services;
using TheToolsmiths.Ddl.Parser.Build.Services;
using TheToolsmiths.Ddl.Parser.Services;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Services;
using TheToolsmiths.Ddl.Parser.TypeResolver.Services;

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
            ConfigurationBuilderCollection builderCollection,
            ConfigurationProviderCollection providerCollection)
        {
            this.RegisterCoreServices();

            this.RegisterPluginServices(configurators, builderCollection, providerCollection);
        }

        private void RegisterCoreServices()
        {
            DdlServicesInitializer.RegisterDdlServices(this.services);

            BuilderServicesInitializer.RegisterBuilderServices(this.services);

            IndexingServicesInitializer.RegisterIndexingServices(this.services);

            ResolverServicesInitializer.RegisterResolverServices(this.services);

            LexerServicesInitializer.RegisterLexerServices(this.services);

            ParserServicesInitializer.RegisterParserServices(this.services);
        }

        private void RegisterPluginServices(
            ParserConfiguratorCollection parserConfigurators,
            ConfigurationBuilderCollection builderCollection,
            ConfigurationProviderCollection providerCollection)
        {
            foreach (var provider in parserConfigurators.Providers)
            {
                var context = new ParserConfiguratorContext(builderCollection);

                provider.Configure(context);
            }

            foreach (var builder in builderCollection.ConfigurationBuilders)
            {
                var context = new ConfigurationBuilderContext(this.services, providerCollection);

                builder.Configure(context);
            }

            foreach (var configurationProvider in providerCollection.ConfigurationProviders)
            {
                var configurationContext = new ConfigurationProviderContext(this.services);

                configurationProvider.Configure(configurationContext);
            }
        }
    }
}
