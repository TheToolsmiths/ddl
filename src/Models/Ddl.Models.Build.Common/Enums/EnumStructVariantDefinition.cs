using TheToolsmiths.Ddl.Models.Build.AttributeUsage;
using TheToolsmiths.Ddl.Models.Build.Items;
using TheToolsmiths.Ddl.Models.Build.Structs.Content;
using TheToolsmiths.Ddl.Models.ItemIds;
using TheToolsmiths.Ddl.Models.Types.Names;

namespace TheToolsmiths.Ddl.Models.Build.Enums
{
    public class EnumStructVariantDefinition : INamedSubItem
    {
        public EnumStructVariantDefinition(
            SubItemId subItemId,
            TypeNameIdentifier subItemName,
            AttributeUseCollection attributes,
            StructContent content)
        {
            this.SubItemId = subItemId;
            this.Attributes = attributes;
            this.Content = content;
            this.SubItemName = subItemName;
        }

        public SubItemId SubItemId { get; }

        public TypeNameIdentifier SubItemName { get; }

        public AttributeUseCollection Attributes { get; }

        public StructContent Content { get; }
    }
}
