using System;
using System.Collections.Generic;
using System.Reflection;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using TheToolsmiths.Ddl.Cli.Abstractions.Plugins;
using TheToolsmiths.Ddl.Services;

namespace TheToolsmiths.Ddl.Cli.Plugins
{
    internal static class PluginSystemRegister
    {
        public static void Register(
            DdlServicesConfigurationBuilder configurationBuilder,
            HostBuilderContext context,
            IServiceCollection services)
        {
            var pluginManagerConfiguration = context.Configuration.GetSection("extensions").Get<PluginManagerConfiguration>();

            // Skip dispose because the registry is disposed by the Service Collection
#pragma warning disable CA2000
            var assembliesRegistry = PluginAssembliesRegistry.Build(pluginManagerConfiguration);
#pragma warning restore CA2000

            services.AddSingleton(assembliesRegistry);

            var exceptions = new List<Exception>();

            // Execute the hosting startup assemblies
            foreach (var assembly in assembliesRegistry.Assemblies)
            {
                foreach (var attribute in assembly.GetCustomAttributes<PluginStartupAttribute>())
                {
                    try
                    {
                        var pluginStartup = (IPluginStartup)Activator.CreateInstance(attribute.HostingStartupType)!;

                        pluginStartup.Configure(configurationBuilder);
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
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
