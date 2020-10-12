using System;
using System.CommandLine.Builder;
using System.CommandLine.Hosting;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TheToolsmiths.Ddl.Cli.Builders;
using TheToolsmiths.Ddl.Cli.Lexers;
using TheToolsmiths.Ddl.Cli.Packagers;
using TheToolsmiths.Ddl.Cli.Parsers;
using TheToolsmiths.Ddl.Cli.Plugins;
using TheToolsmiths.Ddl.Cli.TypeIndexers;
using TheToolsmiths.Ddl.Cli.TypeResolvers;
using TheToolsmiths.Ddl.Cli.Writer;
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

            DdlConfigurationBuilders.RegisterConfigurationBuilders(configurationBuilder);

            PluginSystemRegister.Register(configurationBuilder, context, services);

            RegisterCliApplicationServices(services);

            DdlConfigurationBuilders.BuildAndRegisterConfiguration(configurationBuilder, services);
        }

        private static void RegisterCliApplicationServices(IServiceCollection services)
        {
            services.AddTransient<FileParser>();
            services.AddTransient<GlobParser>();
            services.AddTransient<FileLexer>();

            services.AddTransient<ContentUnitsBuilder>();
            services.AddTransient<PackageTypeIndexer>();
            services.AddTransient<ContentUnitsTypeResolver>();
            services.AddTransient<ContentUnitsPackager>();
            services.AddTransient<PackageWriter>();
            services.AddTransient<WriterProvider>();
        }

        private static void ConfigureAppConfiguration(HostBuilderContext context, IConfigurationBuilder config)
        {
            string location = Assembly.GetEntryAssembly()?.Location ??
                              throw new InvalidOperationException("Can not get Entry Assembly location");

            string configurationDirectory = Path.GetDirectoryName(location) ??
                                            throw new InvalidOperationException("Invalid Entry Assembly location");

            config.AddJsonFile(Path.Join(configurationDirectory, "appsettings.json"));

            config.AddJsonFile(
                Path.Join(configurationDirectory, $"appsettings.{context.HostingEnvironment.EnvironmentName}.json"),
                optional: true);

#if DEBUG
            config.AddJsonFile(Path.Join(configurationDirectory, "appsettings.Debug.json"), optional: true);
#endif
        }
    }
}
