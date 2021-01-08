using Microsoft.Extensions.DependencyInjection;

using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Lexer.Services;
using TheToolsmiths.Ddl.Parser.Build.Services;
using TheToolsmiths.Ddl.Parser.Compiler.Services;
using TheToolsmiths.Ddl.Parser.Packager.Services;
using TheToolsmiths.Ddl.Parser.Services;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Services;
using TheToolsmiths.Ddl.Writer.Services;

namespace TheToolsmiths.Ddl.Services
{
    public static class DdlServicesRegister
    {
        public static void RegisterServices(
            IServiceCollection services,
            DdlConfiguratorCollection configurators,
            ConfigurationBuilderCollection builderCollection,
            ConfigurationProviderCollection providerCollection)
        {
            RegisterCoreServices(services);

            RegisterPluginServices(services, configurators, builderCollection, providerCollection);
        }

        private static void RegisterCoreServices(IServiceCollection services)
        {
            DdlServicesInitializer.RegisterDdlServices(services);

            BuilderServicesInitializer.RegisterBuilderServices(services);

            IndexingServicesInitializer.RegisterIndexingServices(services);

            CompilerServicesInitializer.RegisterResolverServices(services);

            PackagerServicesInitializer.RegisterResolverServices(services);

            LexerServicesInitializer.RegisterLexerServices(services);

            ParserServicesInitializer.RegisterParserServices(services);

            WriterServicesInitializer.RegisterWriterServices(services);
        }

        private static void RegisterPluginServices(
            IServiceCollection services,
            DdlConfiguratorCollection configurators,
            ConfigurationBuilderCollection builderCollection,
            ConfigurationProviderCollection providerCollection)
        {
            foreach (var provider in configurators.Providers)
            {
                var context = new DdlConfiguratorContext(builderCollection);

                provider.Configure(context);
            }

            foreach (var builder in builderCollection.ConfigurationBuilders)
            {
                var context = new ConfigurationBuilderContext(services, providerCollection);

                builder.Configure(context);
            }

            foreach (var configurationProvider in providerCollection.ConfigurationProviders)
            {
                var configurationContext = new ConfigurationProviderContext(services);

                configurationProvider.Configure(configurationContext);
            }
        }
    }
}
