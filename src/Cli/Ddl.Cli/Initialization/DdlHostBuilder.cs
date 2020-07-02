using System.CommandLine.Builder;
using System.CommandLine.Hosting;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using TheToolsmiths.Ddl.Cli.Builders;
using TheToolsmiths.Ddl.Cli.Lexers;
using TheToolsmiths.Ddl.Cli.Parsers;
using TheToolsmiths.Ddl.Cli.Plugins;
using TheToolsmiths.Ddl.Configurations;
using TheToolsmiths.Ddl.Lexer.Writer;
using TheToolsmiths.Ddl.Parser.Build.Configurations;
using TheToolsmiths.Ddl.Parser.Configurations;
using TheToolsmiths.Ddl.Parser.ParserMaps.Builders;
using TheToolsmiths.Ddl.Services;

using IConfigurationBuilder = Microsoft.Extensions.Configuration.IConfigurationBuilder;

namespace TheToolsmiths.Ddl.Cli.Initialization
{
    public static class DdlHostBuilder
    {
        public static CommandLineBuilder UseDdlHost(this CommandLineBuilder builder)
        {
            void ConfigureHost(IHostBuilder host)
            {
                host.ConfigureAppConfiguration(ConfigureAppConfiguration);

                host.ConfigureServices(ConfigureServices);
            }

            IHostBuilder CreateHost(string[] arg)
            {
                return Host.CreateDefaultBuilder();
            }

            return builder.UseHost(CreateHost, ConfigureHost);
        }

        private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            var configurationBuilder = new DdlServicesConfigurationBuilder();

            ParserMapRegistryBuilder parserRegistryBuilder = new ParserMapRegistryBuilder();

            configurationBuilder.ConfigurationBuilders
                .AddConfigurationBuilder<IBuilderConfigurationBuilder>(new BuilderConfigurationBuilder())
                .AddConfigurationBuilder<IParserConfigurationBuilder>(new ParserConfigurationBuilder(parserRegistryBuilder));

            configurationBuilder.ConfigurationRegistryBuilder
                .AddConfigurationProvider<IParserConfigurationProvider>(new ParserConfigurationProvider(parserRegistryBuilder))
                .AddConfigurationProvider<IAstConfigurationProvider>(new AstConfigurationProvider());

            PluginSystemRegister.Register(configurationBuilder, context, services);

            var servicesRegister = new DdlServicesRegister(services);

            var configurationProvider = configurationBuilder.ParserConfigurators.Build();
            var providerCollection = configurationBuilder.ConfigurationRegistryBuilder.Build();
            var builderCollection = configurationBuilder.ConfigurationBuilders.Build();

            servicesRegister.RegisterServices(configurationProvider, builderCollection, providerCollection);

            services.AddTransient<FileParser>();
            services.AddTransient<GlobParser>();
            services.AddTransient<FileLexer>();
            services.AddScoped<DdlLexerTokenWriter>();

            services.AddTransient<ContentUnitsBuilder>();
        }

        private static void ConfigureAppConfiguration(HostBuilderContext context, IConfigurationBuilder config)
        {
            config.AddJsonFile("appsettings.json");

            config.AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", true);

#if DEBUG
            config.AddJsonFile("appsettings.Debug.json", true);
#endif
        }
    }
}
