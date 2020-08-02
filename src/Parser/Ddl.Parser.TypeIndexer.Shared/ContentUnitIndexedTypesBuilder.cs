using System;
using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Models.References.ItemReferences;
using TheToolsmiths.Ddl.Models.References.TypeReferences;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer
{
    public class ContentUnitIndexedTypesBuilder
    {
        private readonly ContentUnitId contentUnitId;

        private readonly Dictionary<ItemReference, ItemTypePathReference> itemIdMap;
        private readonly Dictionary<SubItemReference, SubItemTypePathReference> subItemIdMap;

        public ContentUnitIndexedTypesBuilder(in ContentUnitId contentUnitId)
        {
            this.contentUnitId = contentUnitId;
            this.itemIdMap = new Dictionary<ItemReference, ItemTypePathReference>();
            this.subItemIdMap = new Dictionary<SubItemReference, SubItemTypePathReference>();
        }

        public ContentUnitIndexedTypes Build()
        {
            // TODO: Index and build the indexed types collection
            // I'm skipping implementation for now since the actual indexing usage isn't clear yet

            return new ContentUnitIndexedTypes();
        }

        public void AddType(EntityTypeReference entityReference)
        {
            switch (entityReference)
            {
                case ItemTypePathReference itemTypeReference:
                    this.AddItemType(itemTypeReference);
                    break;
                case SubItemTypePathReference subItemTypeReference:
                    this.AddSubItemType(subItemTypeReference);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(entityReference));
            }
        }

        private void AddSubItemType(SubItemTypePathReference subItemTypeReference)
        {
            this.subItemIdMap.Add(subItemTypeReference.SubItemReference, subItemTypeReference);
        }

        private void AddItemType(ItemTypePathReference itemTypeReference)
        {
            this.itemIdMap.Add(itemTypeReference.ItemReference, itemTypeReference);
        }
    }
}
