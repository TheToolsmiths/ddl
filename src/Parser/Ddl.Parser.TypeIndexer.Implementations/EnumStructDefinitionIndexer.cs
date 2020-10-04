using TheToolsmiths.Ddl.Models.ContentUnits.Items.ItemReferences;
using TheToolsmiths.Ddl.Models.Enums;
using TheToolsmiths.Ddl.Models.References.ItemReferences;
using TheToolsmiths.Ddl.Models.Types.Names;
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
            builder.RootTypeReference = new TypedItemReference(item.TypeName, itemReference);

            TypeNameIdentifier itemTypeName = item.TypeName.ItemName;

            foreach (var itemVariant in item.Variants)
            {
                var subItemName = new TypedSubItemName(itemTypeName, itemVariant.Name);
                var subItemReference = new SubItemReference(item.ItemId, itemVariant.SubItemId);
                var typedSubItemReference = new TypedSubItemReference(subItemName, subItemReference);

                builder.SubItemTypesReferences.Add(typedSubItemReference);
            }

            return builder.CreateSuccessResult();
        }
    }
}
