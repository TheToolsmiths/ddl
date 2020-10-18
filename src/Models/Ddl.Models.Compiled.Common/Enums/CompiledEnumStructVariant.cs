using TheToolsmiths.Ddl.Models.Compiled.AttributeUsage;
using TheToolsmiths.Ddl.Models.Compiled.Items;
using TheToolsmiths.Ddl.Models.Compiled.Structs.Content;
using TheToolsmiths.Ddl.Models.Compiled.Types.Names;
using TheToolsmiths.Ddl.Models.Items;

namespace TheToolsmiths.Ddl.Models.Compiled.Enums
{
    public class CompiledEnumStructVariant : INamedCompiledSubItem
    {
        public CompiledEnumStructVariant(
            SubItemId subItemId,
            QualifiedSubItemTypeName subItemName,
            CompiledAttributeUseCollection attributes,
            CompiledStructContent content)
        {
            this.SubItemId = subItemId;
            this.Attributes = attributes;
            this.Content = content;
            this.SubItemName = subItemName;
        }

        public SubItemId SubItemId { get; }

        public QualifiedSubItemTypeName SubItemName { get; }

        public CompiledAttributeUseCollection Attributes { get; }

        public CompiledStructContent Content { get; }
    }
}
