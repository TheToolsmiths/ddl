using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.Build.AttributeUsage;
using TheToolsmiths.Ddl.Models.Build.Items;
using TheToolsmiths.Ddl.Models.EntryTypes;
using TheToolsmiths.Ddl.Models.ItemIds;
using TheToolsmiths.Ddl.Models.Types.Items;

namespace TheToolsmiths.Ddl.Models.Build.Enums
{
    public class EnumDefinition : INamedRootItem, IAttributableRootItem
    {
        public EnumDefinition(
            ItemId itemId,
            ItemTypeName typeName,
            IReadOnlyList<EnumConstantDefinition> constants,
            AttributeUseCollection attributes)
        {
            this.Constants = constants;
            this.Attributes = attributes;
            this.TypeName = typeName;
            this.ItemId = itemId;
        }

        public ItemId ItemId { get; }

        public ItemTypeName TypeName { get; }

        public ItemType ItemType => CommonItemTypes.EnumDefinition;

        public IReadOnlyList<EnumConstantDefinition> Constants { get; }

        public AttributeUseCollection Attributes { get; }
    }
}
