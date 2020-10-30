using Microsoft.Extensions.DependencyInjection;

using TheToolsmiths.Ddl.Parser.Build.Configurations;
using TheToolsmiths.Ddl.Parser.Compiler.Configurations;
using TheToolsmiths.Ddl.Parser.Configurations.Ast;
using TheToolsmiths.Ddl.Parser.Configurations.Model;
using TheToolsmiths.Ddl.Parser.Configurations.Parser;
using TheToolsmiths.Ddl.Parser.ParserMaps.Builders;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Configurations;
using TheToolsmiths.Ddl.Writer.Configurations.Writer;

namespace TheToolsmiths.Ddl.Services
{
    public static class DdlConfigurationBuilders
    {
        public static void RegisterConfigurationBuilders(DdlServicesConfigurationBuilder configurationBuilder)
        {
            ParserMapRegistryBuilder parserRegistryBuilder = new ParserMapRegistryBuilder();

            // Add Parser Configuration Builders
            configurationBuilder.ConfigurationBuilders
                .AddConfigurationBuilder<IBuilderConfigurationBuilder, BuilderConfigurationBuilder>(new BuilderConfigurationBuilder())
                .AddConfigurationBuilder<IIndexingConfigurationBuilder, IndexingConfigurationBuilder>(new IndexingConfigurationBuilder())
                .AddConfigurationBuilder<ICompilerConfigurationBuilder, CompilerConfigurationBuilder>(new CompilerConfigurationBuilder())
                .AddConfigurationBuilder<IParserConfigurationBuilder, ParserConfigurationBuilder>(new ParserConfigurationBuilder(parserRegistryBuilder));

            // Add Writer Configuration Builders
            configurationBuilder.ConfigurationBuilders
                .AddConfigurationBuilder<IDefinitionWriterConfigurationBuilder, DefinitionWriterConfigurationBuilder>(new DefinitionWriterConfigurationBuilder());


            // Add Registry Builders
            configurationBuilder.ConfigurationRegistryBuilder
                .AddConfigurationProvider<IParserConfigurationProvider>(new ParserConfigurationProvider(parserRegistryBuilder))
                .AddConfigurationProvider<IAstConfigurationProvider>(new AstConfigurationProvider())
                .AddConfigurationProvider<IModelConfigurationProvider>(new ModelConfigurationProvider())
                .AddConfigurationProvider<IWriterConfigurationProvider>(new WriterConfigurationProvider());


            configurationBuilder.Configurators
                .AddConfigurator<Parser.Build.Implementations.Configurators.DdlConfigurator>()
                .AddConfigurator<Parser.Implementations.Configurators.DdlConfigurator>()
                .AddConfigurator<Parser.TypeIndexer.Implementations.Configurators.DdlConfigurator>()
                .AddConfigurator<Parser.Compiler.Implementations.Configurators.DdlConfigurator>()
                .AddConfigurator<Writer.Implementations.Configurators.DdlConfigurator>();
        }

        public static void BuildAndRegisterConfiguration(
            DdlServicesConfigurationBuilder configurationBuilder,
            IServiceCollection services)
        {
            var configurationProvider = configurationBuilder.Configurators.Build();
            var providerCollection = configurationBuilder.ConfigurationRegistryBuilder.Build();
            var builderCollection = configurationBuilder.ConfigurationBuilders.Build();

            var servicesRegister = new DdlServicesRegister(services);
            servicesRegister.RegisterServices(configurationProvider, builderCollection, providerCollection);

        }
    }
}
