using System;
using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Models.Build.Namespaces.Paths;
using TheToolsmiths.Ddl.Models.Compiled.Namespaces.Paths;
using TheToolsmiths.Ddl.Models.Compiled.Package.Content;
using TheToolsmiths.Ddl.Models.Compiled.Package.Namespaces;

namespace TheToolsmiths.Ddl.Parser.Packager.Builders
{
    public class PackageNamespaceBuilder : PackageScopeContentBuilder
    {
        private readonly Dictionary<string, PackageNamespaceBuilder> namespaces;

        internal PackageNamespaceBuilder(
            PackageItemsBuilder itemsBuilder,
            QualifiedNamespacePath namespacePath)
            : base(itemsBuilder)
        {
            this.NamespacePath = namespacePath;
            this.namespaces = new Dictionary<string, PackageNamespaceBuilder>();
        }

        public QualifiedNamespacePath NamespacePath { get; }

        public PackageNamespaceBuilder CreateNamespaceScope(QualifiedNamespacePath childPath)
        {
            if (this.NamespacePath.IsParentOf(childPath) == false)
            {
                throw new System.NotImplementedException();
            }

            var relativePath = QualifiedNamespacePath.GetRelativePath(this.NamespacePath, childPath);

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
                var namespacePath = QualifiedNamespacePath.Append(this.NamespacePath, pathIdentifier);

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
