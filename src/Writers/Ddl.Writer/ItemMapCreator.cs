using System.Collections.Generic;
using System.Text;

using TheToolsmiths.Ddl.Models.Compiled.Items;
using TheToolsmiths.Ddl.Models.Compiled.Items.References;
using TheToolsmiths.Ddl.Models.Compiled.Package.Items;
using TheToolsmiths.Ddl.Models.ItemIds;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Writer
{
    internal static class ItemMapCreator
    {
        private const char KeyPartSeparator = ':';
        
        public static Result<EntityKeyMap> CreateItemMap(PackageItemsCollection packageItems)
        {
            Dictionary<ItemId, string> itemsMap = new();
            Dictionary<(ItemId, SubItemId), (string, string)> subItemsMap = new();
            Dictionary<string, EntityReference> keyMap = new();

            foreach (var packageItem in packageItems.Items)
            {
                IndexItem(packageItem, itemsMap, keyMap);

                IndexSubItems(packageItem, subItemsMap, keyMap);
            }

            var itemMap = new EntityKeyMap(itemsMap, subItemsMap, keyMap);

            return Result.FromValue(itemMap);
        }

        private static void IndexItem(
            PackageItem packageItem,
            Dictionary<ItemId, string> itemsMap,
            IDictionary<string, EntityReference> keyMap)
        {
            string key = CreateItemKey(packageItem);

            itemsMap.Add(packageItem.ItemId, key);
            keyMap.Add(key, new ItemReference(packageItem.ItemId));
        }

        private static void IndexSubItems(
            PackageItem packageItem,
            Dictionary<(ItemId, SubItemId), (string, string)> subItemsMap,
            IDictionary<string, EntityReference> keyMap)
        {
            if (packageItem.Item is not ISubItemOwner subItemOwner)
            {
                return;
            }

            string itemKey = CreateItemKey(packageItem);

            var builder = new StringBuilder();

            foreach (var subItem in subItemOwner.SubItems)
            {
                builder.Clear();

                string subItemKey = CreateSubItemKey(builder, subItem);

                subItemsMap.Add((packageItem.ItemId, subItem.SubItemId), (itemKey, subItemKey));
                keyMap.Add(subItemKey, new SubItemReference(packageItem.ItemId, subItem.SubItemId));
            }
        }

        private static string CreateSubItemKey(StringBuilder builder, ICompiledSubItem subItem)
        {
            builder.AppendJoin(KeyPartSeparator, subItem.SubItemType, subItem.SubItemId.ToInt());

            if (subItem is INamedCompiledSubItem namedSubItem)
            {
                builder.Append(KeyPartSeparator);
                builder.Append(namedSubItem.SubItemName.SubItemTypeName.SubItemName);
            }

            return builder.ToString();
        }

        private static string CreateItemKey(PackageItem packageItem)
        {
            var builder = new StringBuilder();

            var item = packageItem.Item;

            builder.AppendJoin(KeyPartSeparator, item.ItemType, packageItem.ItemId.ToInt());

            if (item is INamedCompiledItem namedItem)
            {
                builder.Append(KeyPartSeparator);
                builder.Append(namedItem.TypeName.ItemTypeName);
            }

            return builder.ToString();
        }
    }
}
