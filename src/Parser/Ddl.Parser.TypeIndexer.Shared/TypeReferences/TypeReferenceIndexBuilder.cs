using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Models.Types.TypePaths.Namespaces;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Packages;
using TheToolsmiths.Ddl.Parser.TypeIndexer.TypeReferences.BuiltinTypes;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer.TypeReferences
{
    public class TypeReferenceIndexBuilder
    {
        public TypeReferenceIndexBuilder()
        {
            this.RootNamespace = new TypeReferenceIndexedNamespaceBuilder();
            this.ContentUnitNamespaceMap = new Dictionary<ContentUnitId, RootNamespacePath>();

            this.BuiltinReferences = new BuiltinTypeReferenceIndexBuilder();
        }

        public Dictionary<ContentUnitId, RootNamespacePath> ContentUnitNamespaceMap { get; }

        public BuiltinTypeReferenceIndexBuilder BuiltinReferences { get; }

        public TypeReferenceIndexedNamespaceBuilder RootNamespace { get; }

        public static TypeReferenceIndex CreateFromPackage(PackageIndexedTypes packageIndexedTypes)
        {
            return TypeReferenceIndexBuilderHelper.CreateFromPackage(packageIndexedTypes);
        }

        public TypeReferenceIndexedNamespaceBuilder GetNamespaceBuilder(RootNamespacePath namespacePath)
        {
            var currentNamespace = this.RootNamespace;

            foreach (string identifier in namespacePath.Identifiers)
            {
                currentNamespace = currentNamespace.GetChildNamespace(identifier);
            }

            return currentNamespace;
        }

        public void AddContentUnitNamespace(in ContentUnitId contentUnitId, RootNamespacePath rootNamespace)
        {
            this.ContentUnitNamespaceMap.Add(contentUnitId, rootNamespace);
        }

        public TypeReferenceIndex Build()
        {
            var rootNamespace = this.RootNamespace.Build();

            BuiltinTypeReferenceResolver builtinTypeReferenceResolver = this.BuiltinReferences.Build();
            return new TypeReferenceIndex(builtinTypeReferenceResolver, rootNamespace, this.ContentUnitNamespaceMap);
        }
    }
}
