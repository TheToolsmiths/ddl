using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TheToolsmiths.Ddl.Models.Compiled.Items.References;
using TheToolsmiths.Ddl.Models.ItemIds;

namespace TheToolsmiths.Ddl.Writer
{
    internal class EntityKeyMap : IEntityKeyMap
    {
        private readonly IReadOnlyDictionary<ItemId, string> itemsMap;
        private readonly IReadOnlyDictionary<string, EntityReference> keyMap;
        private readonly IReadOnlyDictionary<(ItemId, SubItemId), (string itemKey, string subItemKey)> subItemsMap;

        public EntityKeyMap(
            IReadOnlyDictionary<ItemId, string> itemsMap,
            IReadOnlyDictionary<(ItemId, SubItemId), (string, string)> subItemsMap,
            IReadOnlyDictionary<string, EntityReference> keyMap)
        {
            this.subItemsMap = subItemsMap;
            this.itemsMap = itemsMap;
            this.keyMap = keyMap;
        }

        public bool TryGetItemKey(in ItemId itemId, [MaybeNullWhen(false)] out string itemKey)
        {
            return this.itemsMap.TryGetValue(itemId, out itemKey);
        }

        public bool TryGetItemKey(ItemReference itemReference, [MaybeNullWhen(false)] out string itemKey)
        {
            return this.itemsMap.TryGetValue(itemReference.ItemId, out itemKey);
        }

        public bool TryGetItemKey(
            SubItemReference subItemReference,
            [MaybeNullWhen(false)] out string itemKey,
            [MaybeNullWhen(false)] out string subItemKey)
        {
            if (this.subItemsMap.TryGetValue((subItemReference.ItemId, subItemReference.SubItemId), out var keys))
            {
                itemKey = keys.itemKey;
                subItemKey = keys.subItemKey;

                return true;
            }

            itemKey = default;
            subItemKey = default;

            return false;
        }

        public bool TryGetSubItemKey(
            in ItemId itemId,
            in SubItemId subItemId,
            [MaybeNullWhen(false)] out string subItemKey)
        {
            if (this.subItemsMap.TryGetValue((itemId, subItemId), out var keys))
            {
                subItemKey = keys.subItemKey;

                return true;
            }

            subItemKey = default;

            return false;
        }
    }
}
