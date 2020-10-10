using Microsoft.Extensions.DependencyInjection;

using TheToolsmiths.Ddl.Parser.Build.Configurations;
using TheToolsmiths.Ddl.Parser.Configurations.Ast;
using TheToolsmiths.Ddl.Parser.Configurations.Model;
using TheToolsmiths.Ddl.Parser.Configurations.Parser;
using TheToolsmiths.Ddl.Parser.ParserMaps.Builders;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Configurations;
using TheToolsmiths.Ddl.Parser.TypeResolver.Configurations;
using TheToolsmiths.Ddl.Writer.Configurations;
using TheToolsmiths.Ddl.Writer.Configurations.Writer;

namespace TheToolsmiths.Ddl.Services
{
    public static class DdlConfigurationBuilders
    {
        public static void RegisterConfigurationBuilders(DdlServicesConfigurationBuilder configurationBuilder)
        {
            ParserMapRegistryBuilder parserRegistryBuilder = new ParserMapRegistryBuilder();

            configurationBuilder.ConfigurationBuilders
                .AddConfigurationBuilder<IBuilderConfigurationBuilder>(new BuilderConfigurationBuilder())
                .AddConfigurationBuilder<IIndexingConfigurationBuilder>(new IndexingConfigurationBuilder())
                .AddConfigurationBuilder<ITypeResolveConfigurationBuilder>(new TypeResolveConfigurationBuilder())
                .AddConfigurationBuilder<IParserConfigurationBuilder>(new ParserConfigurationBuilder(parserRegistryBuilder))
                .AddConfigurationBuilder<IWriterConfigurationBuilder>(new WriterConfigurationBuilder());

            configurationBuilder.ConfigurationRegistryBuilder
                .AddConfigurationProvider<IParserConfigurationProvider>(new ParserConfigurationProvider(parserRegistryBuilder))
                .AddConfigurationProvider<IAstConfigurationProvider>(new AstConfigurationProvider())
                .AddConfigurationProvider<IWriterConfigurationProvider>(new WriterConfigurationProvider())
                .AddConfigurationProvider<IModelConfigurationProvider>(new ModelConfigurationProvider());

            configurationBuilder.ParserConfigurators
                .AddConfigurator<Parser.Build.Implementations.Configurators.ParserConfigurator>()
                .AddConfigurator<Parser.Implementations.Configurators.ParserConfigurator>()
                .AddConfigurator<Parser.TypeIndexer.Implementations.Configurators.ParserConfigurator>()
                .AddConfigurator<Parser.TypeResolver.Implementations.Configurators.ParserConfigurator>()
                .AddConfigurator<Writer.Implementations.Configurators.ParserConfigurator>();
        }

        public static void BuildAndRegisterConfiguration(
            DdlServicesConfigurationBuilder configurationBuilder,
            IServiceCollection services)
        {
            var configurationProvider = configurationBuilder.ParserConfigurators.Build();
            var providerCollection = configurationBuilder.ConfigurationRegistryBuilder.Build();
            var builderCollection = configurationBuilder.ConfigurationBuilders.Build();

            var servicesRegister = new DdlServicesRegister(services);
            servicesRegister.RegisterServices(configurationProvider, builderCollection, providerCollection);

        }
    }
}
