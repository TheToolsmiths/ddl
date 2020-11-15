﻿using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Models.Compiled.Namespaces.Paths;
using TheToolsmiths.Ddl.Models.Compiled.Package.Items;
using TheToolsmiths.Ddl.Parser.Packager.ContentUnits.Items;

namespace TheToolsmiths.Ddl.Parser.Packager.ContentUnits.Builders
{
    public abstract class ContentUnitPackageScopeContentBuilder
    {
        protected ContentUnitPackageScopeContentBuilder(
            ContentUnitPackageItemsBuilder itemsBuilder,
            QualifiedNamespacePath namespacePath)
        {
            this.NamespacePath = namespacePath;
            this.ItemsBuilder = itemsBuilder;
            this.Items = new List<PackageContentUnitItem>();
            this.Namespaces = new Dictionary<string, ContentUnitPackageNamespaceBuilder>();
            this.Scopes = new List<ContentUnitPackageScopeBuilder>();
        }

        protected ContentUnitPackageItemsBuilder ItemsBuilder { get; }

        public QualifiedNamespacePath NamespacePath { get; }

        public List<PackageContentUnitItem> Items { get; }

        public Dictionary<string, ContentUnitPackageNamespaceBuilder> Namespaces { get; }

        public List<ContentUnitPackageScopeBuilder> Scopes { get; }

        public void AddItem(PackageContentUnitItem item)
        {
            this.ItemsBuilder.AddItem(item);

            this.Items.Add(item);
        }

        public ContentUnitPackageScopeBuilder CreateScope()
        {
            var scopeBuilder = new ContentUnitPackageScopeBuilder(this.ItemsBuilder, this.NamespacePath);

            this.Scopes.Add(scopeBuilder);

            return scopeBuilder;
        }

        public ContentUnitPackageNamespaceBuilder GetNamespace(string identifier)
        {
            if (this.Namespaces.TryGetValue(identifier, out var childBuilder))
            {
                return childBuilder;
            }

            var namespacePath = QualifiedNamespacePath.Append(this.NamespacePath, identifier);

            childBuilder = new ContentUnitPackageNamespaceBuilder(this.ItemsBuilder, namespacePath);

            this.Namespaces.Add(identifier, childBuilder);

            return childBuilder;
        }

        protected PackageContentUnitScopeContent BuildScopeContent()
        {
            var items = new List<PackageItemReference>();

            foreach (var packageItem in this.Items)
            {
                var itemReference = new PackageItemReference(packageItem.ItemId, packageItem.ItemType);
                items.Add(itemReference);
            }

            var namespaces = this.Namespaces.Values.Select(ns => ns.Build()).ToList();
            var scopes = this.Scopes.Select(s => s.Build()).ToList();

            return new PackageContentUnitScopeContent(items, namespaces, scopes);
        }
    }
}