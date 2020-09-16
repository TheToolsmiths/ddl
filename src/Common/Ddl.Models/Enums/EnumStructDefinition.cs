using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Models.EntryTypes;
using TheToolsmiths.Ddl.Models.Types.Names;

namespace TheToolsmiths.Ddl.Models.Enums
{
    public class EnumStructDefinition : ITypedRootItem
    {
        public EnumStructDefinition(TypedItemName typeName, IReadOnlyList<EnumStructVariantDefinition> variants, IReadOnlyList<IAttributeUse> attributes)
        {
            this.TypeName = typeName;
            this.Variants = variants;
            this.Attributes = attributes;
            this.ItemId = ItemId.CreateNew();
        }

        public ItemType ItemType => CommonItemTypes.EnumStructDefinition;

        public ItemId ItemId { get; }

        public TypedItemName TypeName { get; }

        public IReadOnlyList<EnumStructVariantDefinition> Variants { get; }

        public IReadOnlyList<IAttributeUse> Attributes { get; }
    }
}
