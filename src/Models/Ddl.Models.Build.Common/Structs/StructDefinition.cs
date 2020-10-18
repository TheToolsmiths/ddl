using TheToolsmiths.Ddl.Models.Build.AttributeUsage;
using TheToolsmiths.Ddl.Models.Build.Items;
using TheToolsmiths.Ddl.Models.EntryTypes;
using TheToolsmiths.Ddl.Models.Build.Structs.Content;
using TheToolsmiths.Ddl.Models.Items;
using TheToolsmiths.Ddl.Models.Types.Items;

namespace TheToolsmiths.Ddl.Models.Build.Structs
{
    public class StructDefinition : INamedRootItem, IAttributableRootItem
    {
        public StructDefinition(
            ItemId itemId,
            ItemTypeName typeName,
            StructContent content,
            AttributeUseCollection attributes)
        {
            this.ItemId = itemId;
            this.TypeName = typeName;
            this.Content = content;
            this.Attributes = attributes;
        }

        public ItemId ItemId { get; }

        public ItemTypeName TypeName { get; }

        public ItemType ItemType => CommonItemTypes.StructDefinition;

        public StructContent Content { get; }

        public AttributeUseCollection Attributes { get; }
    }
}
