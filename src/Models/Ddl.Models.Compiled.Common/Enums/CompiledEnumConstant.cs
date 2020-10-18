using TheToolsmiths.Ddl.Models.Compiled.AttributeUsage;
using TheToolsmiths.Ddl.Models.Compiled.Items;
using TheToolsmiths.Ddl.Models.Compiled.Types.Names;
using TheToolsmiths.Ddl.Models.Items;
using TheToolsmiths.Ddl.Models.Literals;

namespace TheToolsmiths.Ddl.Models.Compiled.Enums
{
    public class CompiledEnumConstant : INamedCompiledSubItem
    {
        public CompiledEnumConstant(
            SubItemId subItemId,
            QualifiedSubItemTypeName subItemName,
            CompiledAttributeUseCollection attributes,
            LiteralValue value)
        {
            this.SubItemId = subItemId;
            this.Attributes = attributes;
            this.Value = value;
            this.SubItemName = subItemName;
        }

        public SubItemId SubItemId { get; }

        public QualifiedSubItemTypeName SubItemName { get; }

        public CompiledAttributeUseCollection Attributes { get; }

        public LiteralValue Value { get; }
    }
}
