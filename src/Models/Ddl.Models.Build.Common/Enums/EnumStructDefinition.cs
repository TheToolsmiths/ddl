using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.AttributeUsage;
using TheToolsmiths.Ddl.Models.Build.Items;
using TheToolsmiths.Ddl.Models.EntryTypes;
using TheToolsmiths.Ddl.Models.Items;
using TheToolsmiths.Ddl.Models.Types.Items;

namespace TheToolsmiths.Ddl.Models.Build.Enums
{
    public class EnumStructDefinition : INamedRootItem, IAttributableRootItem
    {
        public EnumStructDefinition(
            ItemId itemId,
            ItemTypeName typeName,
            IReadOnlyList<EnumStructVariantDefinition> variants,
            AttributeUseCollection attributes)
        {
            this.ItemId = itemId;
            this.TypeName = typeName;
            this.Variants = variants;
            this.Attributes = attributes;
        }

        public ItemId ItemId { get; }

        public ItemTypeName TypeName { get; }

        public ItemType ItemType => CommonItemTypes.EnumStructDefinition;

        public IReadOnlyList<EnumStructVariantDefinition> Variants { get; }

        public AttributeUseCollection Attributes { get; }
    }
}
