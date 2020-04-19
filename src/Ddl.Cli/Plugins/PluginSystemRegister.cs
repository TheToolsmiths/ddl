using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TheToolsmiths.Ddl.Shared.Plugins;

namespace TheToolsmiths.Ddl.Cli.Plugins
{
    internal static class PluginSystemRegister
    {
        public static void RegisterPlugins(this IServiceCollection services, HostBuilderContext context)
        {
            var configuration = context.Configuration;

            var assembliesConfiguration = configuration.GetSection("extensions").Get<PluginManagerConfiguration>();

            var pluginAssemblies = new PluginAssembliesRegistry(assembliesConfiguration);

            services.AddSingleton(pluginAssemblies);

            pluginAssemblies.Initialize();

            var exceptions = new List<Exception>();

            var builder = new PluginHostBuilder(context.Configuration, services);

            // Execute the hosting startup assemblies
            foreach (var assembly in pluginAssemblies.Assemblies)
            {
                try
                {
                    foreach (var attribute in assembly.GetCustomAttributes<PluginStartupAttribute>())
                    {
                        var hostingStartup = (IPluginStartup)Activator.CreateInstance(attribute.HostingStartupType)!;

                        hostingStartup.Configure(builder);
                    }
                }
                catch (Exception ex)
                {
                    // Capture any errors that happen during startup
                    var exception = new InvalidOperationException(
                        $"Startup assembly '{assembly.FullName}' failed to execute. See the inner exception for more details.",
                        ex);
                    exceptions.Add(exception);
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
