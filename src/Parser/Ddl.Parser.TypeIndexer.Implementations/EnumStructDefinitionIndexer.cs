using TheToolsmiths.Ddl.Models.Build.Enums;
using TheToolsmiths.Ddl.Models.Build.Indexing.Items;
using TheToolsmiths.Ddl.Models.Build.Items.References;
using TheToolsmiths.Ddl.Models.Types.Items;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Contexts;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Results;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer.Implementations
{
    internal class EnumStructDefinitionIndexer : IRootItemIndexer<EnumStructDefinition>
    {
        public RootItemIndexResult IndexItem(IRootItemIndexContext itemContext, EnumStructDefinition item)
        {
            var builder = new RootItemIndexResultBuilder();

            var itemReference = new ItemReference(item.ItemId);
            builder.ItemType = new ItemTypeIndexEntry(item.TypeName, itemReference);

            var itemTypeName = item.TypeName.ItemName;

            foreach (var itemVariant in item.Variants)
            {
                var subItemName = new SubItemTypeName(itemTypeName, itemVariant.SubItemName);

                var subItemReference = new SubItemReference(item.ItemId, itemVariant.SubItemId);

                var typedSubItemReference = new SubItemTypeIndexEntry(subItemName, subItemReference);

                builder.SubItemTypes.Add(typedSubItemReference);
            }

            return builder.CreateSuccessResult();
        }
    }
}
