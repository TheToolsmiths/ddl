using System.CommandLine.Builder;
using System.CommandLine.Hosting;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using TheToolsmiths.Ddl.Cli.Builders;
using TheToolsmiths.Ddl.Cli.Lexers;
using TheToolsmiths.Ddl.Cli.Parsers;
using TheToolsmiths.Ddl.Cli.Plugins;
using TheToolsmiths.Ddl.Cli.TypeIndexers;
using TheToolsmiths.Ddl.Cli.TypeResolvers;
using TheToolsmiths.Ddl.Lexer.Writer;
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

            DdlCoreServices.RegisterCoreServices(configurationBuilder);

            PluginSystemRegister.Register(configurationBuilder, context, services);

            RegisterCliApplicationServices(services);

            DdlCoreServices.BuildAndRegisterConfiguration(configurationBuilder, services);
        }

        private static void RegisterCliApplicationServices(IServiceCollection services)
        {
            services.AddTransient<FileParser>();
            services.AddTransient<GlobParser>();
            services.AddTransient<FileLexer>();
            services.AddScoped<DdlLexerTokenWriter>();

            services.AddTransient<ContentUnitsBuilder>();
            services.AddTransient<ContentUnitsTypeIndexer>();
            services.AddTransient<ContentUnitsTypeResolver>();
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
