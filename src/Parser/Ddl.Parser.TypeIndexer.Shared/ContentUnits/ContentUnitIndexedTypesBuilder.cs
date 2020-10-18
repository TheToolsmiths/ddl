using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.Namespaces.Paths;
using TheToolsmiths.Ddl.Models.Build.Types.References;
using TheToolsmiths.Ddl.Models.Compiled.ContentUnits;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer.ContentUnits
{
    public static class ContentUnitIndexedTypesBuilder
    {
        public static ContentUnitIndexedTypes BuildFromList(
            in ContentUnitId contentUnitId,
            RootNamespacePath contentUnitNamespace,
            IReadOnlyList<EntityTypeReference> indexedTypes)
        {
            var rootNamespaceBuilder = ContentUnitIndexedNamespaceBuilder.CreateRoot();

            foreach (var indexedType in indexedTypes)
            {
                var namespaceBuilder = rootNamespaceBuilder.TryGetNamespaceBuilder(indexedType.NamespacePath);

                switch (indexedType)
                {
                    case ItemTypePathReference itemTypeReference:
                        namespaceBuilder.IndexItemType(itemTypeReference);
                        break;
                    case SubItemTypePathReference subItemTypeReference:
                        namespaceBuilder.IndexSubItemType(subItemTypeReference);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(indexedType));
                }
            }

            var rootIndexedNamespace = rootNamespaceBuilder.Build();

            return new ContentUnitIndexedTypes(contentUnitId, contentUnitNamespace, rootIndexedNamespace);
        }
    }
}
