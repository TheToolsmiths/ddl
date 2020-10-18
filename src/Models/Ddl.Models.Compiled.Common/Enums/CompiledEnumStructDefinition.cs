using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Compiled.AttributeUsage;
using TheToolsmiths.Ddl.Models.Compiled.Items;
using TheToolsmiths.Ddl.Models.Compiled.Types.Names;
using TheToolsmiths.Ddl.Models.EntryTypes;
using TheToolsmiths.Ddl.Models.Items;

namespace TheToolsmiths.Ddl.Models.Compiled.Enums
{
    public class CompiledEnumStructDefinition : INamedCompiledItem, IAttributableCompiledItem
    {
        public CompiledEnumStructDefinition(
            ItemId itemId,
            QualifiedItemTypeName typeName,
            IReadOnlyList<CompiledEnumStructVariant> variants,
            CompiledAttributeUseCollection attributes)
        {
            this.ItemId = itemId;
            this.TypeName = typeName;
            this.Variants = variants;
            this.Attributes = attributes;
        }

        public ItemId ItemId { get; }

        public QualifiedItemTypeName TypeName { get; }

        public ItemType ItemType => CommonItemTypes.EnumStructDefinition;

        public IReadOnlyList<CompiledEnumStructVariant> Variants { get; }

        public CompiledAttributeUseCollection Attributes { get; }
    }
}
