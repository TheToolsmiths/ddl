using TheToolsmiths.Ddl.Models.Compiled.AttributeUsage;
using TheToolsmiths.Ddl.Models.Compiled.Items;
using TheToolsmiths.Ddl.Models.Compiled.Structs.Content;
using TheToolsmiths.Ddl.Models.Compiled.Types.Names;
using TheToolsmiths.Ddl.Models.EntryTypes;
using TheToolsmiths.Ddl.Models.Items;

namespace TheToolsmiths.Ddl.Models.Compiled.Structs
{
    public class CompiledStructDefinition : INamedCompiledItem, IAttributableCompiledItem
    {
        public CompiledStructDefinition(
            ItemId itemId,
            QualifiedItemTypeName typeName,
            CompiledStructContent content,
            CompiledAttributeUseCollection attributes)
        {
            this.ItemId = itemId;
            this.TypeName = typeName;
            this.Content = content;
            this.Attributes = attributes;
        }

        public ItemId ItemId { get; }

        public QualifiedItemTypeName TypeName { get; }

        public ItemType ItemType => CommonItemTypes.StructDefinition;

        public CompiledStructContent Content { get; }

        public CompiledAttributeUseCollection Attributes { get; }
    }
}
