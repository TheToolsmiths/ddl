using TheToolsmiths.Ddl.Parser.TypeIndexer.ContentUnits;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Packages;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer.TypeReferences
{
    internal class TypeReferenceIndexBuilderHelper
    {
        public static TypeReferenceIndex CreateFromPackage(PackageIndexedTypes packageIndexedTypes)
        {
            var builder = new TypeReferenceIndexBuilder();

            foreach (var contentUnit in packageIndexedTypes.ContentUnits)
            {
                AddContentUnit(builder, contentUnit);
            }

            return builder.Build();
        }

        private static void AddContentUnit(TypeReferenceIndexBuilder builder, ContentUnitIndexedTypes contentUnit)
        {
            var namespaceBuilder = builder.GetNamespaceBuilder(contentUnit.ContentUnitNamespace);

            builder.AddContentUnitNamespace(contentUnit.ContentUnitId, contentUnit.ContentUnitNamespace);

            AddNamespace(contentUnit.RootIndexedNamespace, namespaceBuilder);
        }

        private static void AddNamespace(
            ContentUnitIndexedNamespace indexedNamespace,
            TypeReferenceIndexedNamespaceBuilder namespaceBuilder)
        {
            foreach (var (itemName, indexedPath) in indexedNamespace.Items)
            {
                foreach (var pathReference in indexedPath.Items)
                {
                    namespaceBuilder.Items.AddItemReference(itemName, pathReference);
                }

                foreach (var (subItemName, pathReferences) in indexedPath.SubItems)
                {
                    foreach (var pathReference in pathReferences)
                    {
                        namespaceBuilder.Items.AddSubItemReference(itemName, subItemName, pathReference);
                    }
                }
            }

            foreach (var (namespaceIdentifier, childNamespace) in indexedNamespace.ChildNamespaces)
            {
                var childNamespaceBuilder = namespaceBuilder.GetChildNamespace(namespaceIdentifier);

                AddNamespace(childNamespace, childNamespaceBuilder);
            }
        }
    }
}
