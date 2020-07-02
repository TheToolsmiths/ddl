using System.CommandLine.Builder;
using System.CommandLine.Hosting;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using TheToolsmiths.Ddl.Cli.Builders;
using TheToolsmiths.Ddl.Cli.Lexers;
using TheToolsmiths.Ddl.Cli.Parsers;
using TheToolsmiths.Ddl.Cli.Plugins;
using TheToolsmiths.Ddl.Lexer.Writer;
using TheToolsmiths.Ddl.Parser.Configurations;
using TheToolsmiths.Ddl.Services;

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

            configurationBuilder.ConfigurationRegistryBuilder
                .AddProvider<IParserConfigurationProvider, ParserConfigurationProvider>()
                .AddProvider<IAstConfigurationProvider, AstConfigurationProvider>();

            PluginSystemRegister.Register(configurationBuilder, context, services);

            var servicesRegister = new DdlServicesRegister(services);

            var configurationProvider = configurationBuilder.ParserConfigurators.Build();
            var providerCollection = configurationBuilder.ConfigurationRegistryBuilder.Build();

            servicesRegister.RegisterServices(configurationProvider, providerCollection);

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
