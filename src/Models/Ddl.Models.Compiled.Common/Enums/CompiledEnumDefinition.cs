using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Compiled.AttributeUsage;
using TheToolsmiths.Ddl.Models.Compiled.Items;
using TheToolsmiths.Ddl.Models.Compiled.Types.Names;
using TheToolsmiths.Ddl.Models.EntryTypes;
using TheToolsmiths.Ddl.Models.Items;

namespace TheToolsmiths.Ddl.Models.Compiled.Enums
{
    public class CompiledEnumDefinition : INamedCompiledItem, IAttributableCompiledItem
    {
        public CompiledEnumDefinition(
            ItemId itemId,
            QualifiedItemTypeName typeName,
            IReadOnlyList<CompiledEnumConstant> constants,
            CompiledAttributeUseCollection attributes)
        {
            this.Constants = constants;
            this.Attributes = attributes;
            this.TypeName = typeName;
            this.ItemId = itemId;
        }

        public ItemId ItemId { get; }

        public QualifiedItemTypeName TypeName { get; }

        public ItemType ItemType => CommonItemTypes.EnumDefinition;

        public IReadOnlyList<CompiledEnumConstant> Constants { get; }

        public CompiledAttributeUseCollection Attributes { get; }
    }
}
