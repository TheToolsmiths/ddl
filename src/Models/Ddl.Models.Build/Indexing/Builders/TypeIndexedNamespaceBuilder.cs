﻿using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.Namespaces.Paths;

namespace TheToolsmiths.Ddl.Models.Build.Indexing.Builders
{
    public class TypeIndexedNamespaceBuilder
    {
        public TypeIndexedNamespaceBuilder(string identifier)
        {
            this.Identifier = identifier;
            this.Items = new TypeIndexedItemsBuilder();
            this.ChildNamespaces = new Dictionary<string, TypeIndexedNamespaceBuilder>();
        }

        public string Identifier { get; set; }

        public Dictionary<string, TypeIndexedNamespaceBuilder> ChildNamespaces { get; }

        public TypeIndexedItemsBuilder Items { get; }

        public TypeIndexedNamespaceBuilder GetChildNamespace(string identifier)
        {
            if (this.ChildNamespaces.TryGetValue(identifier, out var childNamespaceBuilder) == false)
            {
                childNamespaceBuilder = new TypeIndexedNamespaceBuilder(identifier);

                this.ChildNamespaces.Add(identifier, childNamespaceBuilder);
            }

            return childNamespaceBuilder;
        }

        public TypeIndexedNamespace Build()
        {
            return this.BuildInternal(null, null);
        }

        private TypeIndexedNamespace BuildInternal(
            TypeIndexedNamespace? rootNamespace,
            TypeIndexedNamespace? parentNamespace)
        {
            string identifier = this.Identifier ?? throw new InvalidOperationException($"{nameof(this.Identifier)} is (null) or empty");

            var items = this.Items.Build();
            var childNamespaces = new Dictionary<string, TypeIndexedNamespace>();

            RootNamespacePath namespacePath;
            if (parentNamespace == null)
            {
                namespacePath = RootNamespacePath.EmptyRoot;
            }
            else
            {
                var parentNamespacePath = parentNamespace.NamespacePath;

                namespacePath = RootNamespacePath.Append(parentNamespacePath, identifier);
            }

            var indexedNamespace = new TypeIndexedNamespace(identifier, namespacePath, items, parentNamespace, rootNamespace, childNamespaces);

            foreach (var (key, childBuilder) in this.ChildNamespaces)
            {
                var childNamespace = childBuilder.BuildInternal(rootNamespace ?? indexedNamespace, indexedNamespace);

                childNamespaces.Add(key, childNamespace);
            }

            return indexedNamespace;
        }
    }
}