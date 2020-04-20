﻿using System.CommandLine.Builder;
using System.CommandLine.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TheToolsmiths.Ddl.Cli.FileParsers;
using TheToolsmiths.Ddl.Cli.Lexers;
using TheToolsmiths.Ddl.Cli.Plugins;
using TheToolsmiths.Ddl.Lexer.Services;
using TheToolsmiths.Ddl.Parser.Services;

namespace TheToolsmiths.Ddl.Cli.Initialization
{
    public static class TranspilerHostBuilder
    {
        public static CommandLineBuilder UseTranspilerHost(this CommandLineBuilder builder)
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
            services.RegisterLexerServices();
            services.RegisterParserServices();

            services.AddTransient<FileParser>();
            services.AddTransient<FileLexer>();
            services.AddScoped<DdlLexerTokenWriter>();

            services.RegisterPlugins(context);
        }

        private static void ConfigureAppConfiguration(HostBuilderContext context, IConfigurationBuilder config)
        {
            config.AddJsonFile("appsettings.json");

            config.AddJsonFile($"appsettings.{context.HostingEnvironment}.json", optional: true);

#if DEBUG
            config.AddJsonFile($"appsettings.Debug.json", optional: true);
#endif
        }
    }
}