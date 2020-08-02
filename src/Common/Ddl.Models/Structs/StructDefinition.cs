using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Models.EntryTypes;
using TheToolsmiths.Ddl.Models.Structs.Content;
using TheToolsmiths.Ddl.Models.Types.Names;

namespace TheToolsmiths.Ddl.Models.Structs
{
    public class StructDefinition : ITypedRootItem
    {
        public StructDefinition(TypedItemName typeName, StructDefinitionContent content)
        {
            this.TypeName = typeName;
            this.Content = content;
            this.ItemId = ItemId.CreateNew();
        }

        public ItemType ItemType => CommonItemTypes.StructDefinition;

        public TypedItemName TypeName { get; }

        public StructDefinitionContent Content { get; }

        public ItemId ItemId { get; }
    }
}
