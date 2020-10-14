using System;
using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Models.Build.Package.Content;
using TheToolsmiths.Ddl.Models.Build.Package.Namespaces;
using TheToolsmiths.Ddl.Models.Build.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Parser.Packager.Builders
{
    public class PackageNamespaceBuilder : PackageScopeContentBuilder
    {
        private readonly Dictionary<string, PackageNamespaceBuilder> namespaces;

        internal PackageNamespaceBuilder(
            PackageItemsBuilder itemsBuilder,
            RootNamespacePath namespacePath)
            : base(itemsBuilder)
        {
            this.NamespacePath = namespacePath;
            this.namespaces = new Dictionary<string, PackageNamespaceBuilder>();
        }

        public RootNamespacePath NamespacePath { get; }

        public PackageNamespaceBuilder CreateNamespaceScope(RootNamespacePath childPath)
        {
            if (this.NamespacePath.IsParentOf(childPath) == false)
            {
                throw new System.NotImplementedException();
            }

            var relativePath = RootNamespacePath.GetRelativePath(this.NamespacePath, childPath);

            // Relative Namespace Path can't be rooted!
            if (relativePath.IsRooted)
            {
                throw new NotImplementedException();
            }

            var currentNamespace = this;

            foreach (string pathIdentifier in relativePath.Identifiers)
            {
                currentNamespace = currentNamespace.GetOrCreateNamespace(pathIdentifier);
            }

            return currentNamespace;
        }

        public PackageNamespaceBuilder GetOrCreateNamespace(string pathIdentifier)
        {
            if (this.namespaces.TryGetValue(pathIdentifier, out var namespaceBuilder) == false)
            {
                var namespacePath = RootNamespacePath.Append((NamespacePath)this.NamespacePath, pathIdentifier);

                namespaceBuilder = new PackageNamespaceBuilder(this.itemsBuilder, namespacePath);

                this.namespaces.Add(pathIdentifier, namespaceBuilder);
            }

            return namespaceBuilder;
        }

        public PackageNamespace Build()
        {
            var scopeContent = this.BuildScopeContent();

            return new PackageNamespace(this.NamespacePath, scopeContent);
        }

        protected override PackageScopeContent BuildScopeContent()
        {
            var buildItems = this.BuildItems();
            var buildScopes = this.BuildScopes();

            var buildNamespaces = this.namespaces.Values.Select(n => n.Build()).ToList();

            return new PackageNamespaceContent(buildItems, buildNamespaces, buildScopes);
        }
    }
}
