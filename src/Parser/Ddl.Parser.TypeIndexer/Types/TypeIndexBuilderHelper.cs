using TheToolsmiths.Ddl.Models.Build.Types.Index;
using TheToolsmiths.Ddl.Parser.TypeIndexer.ContentUnits;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Packages;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer.Types
{
    public static class TypeIndexBuilderHelper
    {
        public static TypeIndex CreateFromPackage(PackageIndexedTypes packageIndexedTypes)
        {
            var builder = new TypeIndexBuilder();

            foreach (var contentUnit in packageIndexedTypes.ContentUnits)
            {
                AddContentUnit(builder, contentUnit);
            }

            return builder.Build();
        }

        private static void AddContentUnit(TypeIndexBuilder builder, ContentUnitIndexedTypes contentUnit)
        {
            var namespaceBuilder = builder.GetNamespaceBuilder(contentUnit.ContentUnitNamespace);

            AddNamespace(contentUnit.RootIndexedNamespace, namespaceBuilder);
        }

        private static void AddNamespace(
            ContentUnitIndexedNamespace indexedNamespace,
            TypeIndexedNamespaceBuilder namespaceBuilder)
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
