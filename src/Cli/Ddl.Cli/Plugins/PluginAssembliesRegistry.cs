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
        private readonly PluginManagerConfiguration configuration;

        private readonly AssemblyLoadContext context;

        public PluginAssembliesRegistry(PluginManagerConfiguration configuration)
        {
            this.context = new AssemblyLoadContext("PluginManager", true);
            this.configuration = configuration;
        }

        public IEnumerable<Assembly> Assemblies => this.context.Assemblies;

        public void Initialize()
        {
            var assemblyPaths = this.ResolveAssemblyPaths();

            this.CreatePluginContext(assemblyPaths);
        }

        public void Dispose()
        {
            this.context.Unload();
        }

        private void CreatePluginContext(IEnumerable<FileInfo> assemblyPaths)
        {
            foreach (var assemblyPath in assemblyPaths)
            {
                this.context.LoadFromAssemblyPath(assemblyPath.FullName);
            }
        }

        private IReadOnlyList<FileInfo> ResolveAssemblyPaths()
        {
            if (this.configuration.Paths == null)
            {
                return Array.Empty<FileInfo>();
            }

            var assemblyFiles = new HashSet<FileInfo>();

            foreach (string path in this.configuration.Paths)
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
