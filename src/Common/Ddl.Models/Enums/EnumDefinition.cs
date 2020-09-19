using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Models.EntryTypes;
using TheToolsmiths.Ddl.Models.Types.Names;

namespace TheToolsmiths.Ddl.Models.Enums
{
    public class EnumDefinition : ITypedRootItem
    {
        public EnumDefinition(
            ItemId itemId,
            TypedItemName typeName,
            IReadOnlyList<EnumConstantDefinition> constants,
            AttributeUseCollection attributes)
        {
            this.TypeName = typeName;
            this.Constants = constants;
            this.Attributes = attributes;
            this.ItemId = itemId;
        }

        public EnumDefinition(
            TypedItemName typeName,
            IReadOnlyList<EnumConstantDefinition> constants,
            AttributeUseCollection attributes)
            : this(ItemId.CreateNew(), typeName, constants, attributes)
        {
        }

        public TypedItemName TypeName { get; }

        public IReadOnlyList<EnumConstantDefinition> Constants { get; }

        public AttributeUseCollection Attributes { get; }

        public ItemType ItemType => CommonItemTypes.EnumDefinition;

        public ItemId ItemId { get; }
    }
}
