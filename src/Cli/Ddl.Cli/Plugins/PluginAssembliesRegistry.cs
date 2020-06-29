using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

using TheToolsmiths.Ddl.Cli.Utils;

namespace TheToolsmiths.Ddl.Cli.Plugins
{
    internal class PluginAssembliesRegistry : IPluginAssembliesRegistry, IDisposable
    {
        private readonly AssemblyLoadContext context;

        public PluginAssembliesRegistry(AssemblyLoadContext context)
        {
            this.context = context;
        }

        public IEnumerable<Assembly> Assemblies => this.context.Assemblies;

        public void Dispose()
        {
            this.context.Unload();
        }

        public static PluginAssembliesRegistry Build(PluginManagerConfiguration configuration)
        {
            var assemblyPaths = ResolveAssemblyPaths();

            var context = new AssemblyLoadContext("PluginManager", true);

            foreach (var assemblyPath in assemblyPaths)
            {
                context.LoadFromAssemblyPath(assemblyPath.FullName);
            }

            return new PluginAssembliesRegistry(context);

            IReadOnlyList<FileInfo> ResolveAssemblyPaths()
            {
                if (configuration.Paths == null)
                {
                    return Array.Empty<FileInfo>();
                }

                var assemblyFiles = new HashSet<FileInfo>();

                foreach (string path in configuration.Paths)
                {
                    foreach (var fileInfo in FileGlobResolver.ResolveAbsoluteFilesForCurrentDirectory(path))
                    {
                        assemblyFiles.Add(fileInfo);
                    }
                }

                return assemblyFiles.ToList();
            }
        }
    }
}
