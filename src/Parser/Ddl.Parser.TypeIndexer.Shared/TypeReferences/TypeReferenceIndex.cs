using System;
using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Models.Types.TypePaths.Namespaces;
using TheToolsmiths.Ddl.Parser.TypeIndexer.TypeReferences.BuiltinTypes;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer.TypeReferences
{
    public class TypeReferenceIndex
    {
        public TypeReferenceIndex(
            BuiltinTypeReferenceResolver builtinTypeReferenceResolver,
            TypeReferenceIndexedNamespace rootNamespace,
            IReadOnlyDictionary<ContentUnitId, RootNamespacePath> contentUnitNamespaceMap)
        {
            this.BuiltinTypeReferenceResolver = builtinTypeReferenceResolver;
            this.RootNamespace = rootNamespace;
            this.ContentUnitNamespaceMap = contentUnitNamespaceMap;
        }

        public BuiltinTypeReferenceResolver BuiltinTypeReferenceResolver { get; }

        public TypeReferenceIndexedNamespace RootNamespace { get; }

        public IReadOnlyDictionary<ContentUnitId, RootNamespacePath> ContentUnitNamespaceMap { get; }

        public TypeReferenceIndexedNamespace GetContentUnitNamespaceIndex(ContentUnitId contentUnitId)
        {
            if (this.ContentUnitNamespaceMap.TryGetValue(contentUnitId, out var rootNamespace) == false)
            {
                throw new NotImplementedException();
            }

            return this.GetNamespaceIndex(rootNamespace);
        }

        private TypeReferenceIndexedNamespace GetNamespaceIndex(RootNamespacePath rootNamespace)
        {
            var currentNamespace = this.RootNamespace;
            foreach (string namespaceIdentifier in rootNamespace.Identifiers)
            {
                if (currentNamespace.ChildNamespaces.TryGetValue(namespaceIdentifier, out var indexedNamespace) == false)
                {
                    throw new NotImplementedException();
                }

                currentNamespace = indexedNamespace;
            }

            return currentNamespace;
        }
    }
}
