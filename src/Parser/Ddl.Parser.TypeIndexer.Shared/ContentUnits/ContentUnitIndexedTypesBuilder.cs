using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Models.References.TypeReferences;
using TheToolsmiths.Ddl.Models.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer.ContentUnits
{
    public static class ContentUnitIndexedTypesBuilder
    {
        public static ContentUnitIndexedTypes BuildFromList(
            in ContentUnitId contentUnitId,
            RootNamespacePath contentUnitNamespace,
            IReadOnlyList<EntityTypeReference> indexedTypes)
        {
            // TODO: Index and build the indexed types collection
            // I'm skipping implementation for now since the actual indexing usage isn't clear yet

            List<ItemTypePathReference> items = new List<ItemTypePathReference>();
            List<SubItemTypePathReference> subItems = new List<SubItemTypePathReference>();
            List<EntityTypeReference> entities = new List<EntityTypeReference>();

            var rootNamespaceBuilder = ContentUnitIndexedNamespaceBuilder.CreateRoot();

            foreach (var indexedType in indexedTypes)
            {
                var namespaceBuilder = rootNamespaceBuilder.TryGetNamespaceBuilder(indexedType.NamespacePath);

                switch (indexedType)
                {
                    case ItemTypePathReference itemTypeReference:
                        IndexItemType(itemTypeReference, namespaceBuilder);
                        break;
                    case SubItemTypePathReference subItemTypeReference:
                        IndexSubItemType(subItemTypeReference, namespaceBuilder);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(indexedType));
                }
            }

            var rootIndexedNamespace = rootNamespaceBuilder.Build();

            return new ContentUnitIndexedTypes(contentUnitId, contentUnitNamespace, rootIndexedNamespace);

            void IndexItemType(
                ItemTypePathReference itemTypeReference,
                ContentUnitIndexedNamespaceBuilder namespaceBuilder)
            {
                namespaceBuilder.IndexItemType(itemTypeReference);

                items.Add(itemTypeReference);
                entities.Add(itemTypeReference);
            }

            void IndexSubItemType(
                SubItemTypePathReference subItemTypeReference,
                ContentUnitIndexedNamespaceBuilder namespaceBuilder)
            {
                namespaceBuilder.IndexSubItemType(subItemTypeReference);

                subItems.Add(subItemTypeReference);
                entities.Add(subItemTypeReference);
            }
        }
    }
}
