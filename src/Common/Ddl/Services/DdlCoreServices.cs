﻿using Microsoft.Extensions.DependencyInjection;

using TheToolsmiths.Ddl.Parser.Build.Configurations;
using TheToolsmiths.Ddl.Parser.Configurations.Ast;
using TheToolsmiths.Ddl.Parser.Configurations.Model;
using TheToolsmiths.Ddl.Parser.Configurations.Parser;
using TheToolsmiths.Ddl.Parser.ParserMaps.Builders;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Configurations;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Implementations.Configurators;

namespace TheToolsmiths.Ddl.Services
{
    public static class DdlCoreServices
    {
        public static void RegisterCoreServices(DdlServicesConfigurationBuilder configurationBuilder)
        {
            ParserMapRegistryBuilder parserRegistryBuilder = new ParserMapRegistryBuilder();

            configurationBuilder.ConfigurationBuilders
                .AddConfigurationBuilder<IBuilderConfigurationBuilder>(new BuilderConfigurationBuilder())
                .AddConfigurationBuilder<IIndexingConfigurationBuilder>(new IndexingConfigurationBuilder())
                .AddConfigurationBuilder<IParserConfigurationBuilder>(new ParserConfigurationBuilder(parserRegistryBuilder));

            configurationBuilder.ConfigurationRegistryBuilder
                .AddConfigurationProvider<IParserConfigurationProvider>(new ParserConfigurationProvider(parserRegistryBuilder))
                .AddConfigurationProvider<IAstConfigurationProvider>(new AstConfigurationProvider())
                .AddConfigurationProvider<IModelConfigurationProvider>(new ModelConfigurationProvider());

            configurationBuilder.ParserConfigurators
                .AddConfigurator<Parser.Build.Implementations.Configurators.ParserConfigurator>()
                .AddConfigurator<Parser.Implementations.Configurators.ParserConfigurator>()
                .AddConfigurator<ParserConfigurator>();
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
