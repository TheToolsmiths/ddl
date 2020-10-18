using TheToolsmiths.Ddl.Models.Build.AttributeUsage;
using TheToolsmiths.Ddl.Models.Build.Items;
using TheToolsmiths.Ddl.Models.Items;
using TheToolsmiths.Ddl.Models.Literals;
using TheToolsmiths.Ddl.Models.Types.Names;

namespace TheToolsmiths.Ddl.Models.Build.Enums
{
    public class EnumConstantDefinition : INamedSubItem
    {
        public EnumConstantDefinition(
            SubItemId subItemId,
            TypeNameIdentifier subItemName,
            AttributeUseCollection attributes,
            LiteralValue value)
        {
            this.SubItemId = subItemId;
            this.Attributes = attributes;
            this.Value = value;
            this.SubItemName = subItemName;
        }

        public SubItemId SubItemId { get; }

        public TypeNameIdentifier SubItemName { get; }

        public AttributeUseCollection Attributes { get; }

        public LiteralValue Value { get; }
    }
}
