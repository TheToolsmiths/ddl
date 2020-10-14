using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Compiled.AttributeUsage;
using TheToolsmiths.Ddl.Models.Compiled.ContentUnits;
using TheToolsmiths.Ddl.Models.Compiled.ContentUnits.Items;
using TheToolsmiths.Ddl.Models.Compiled.EntryTypes;
using TheToolsmiths.Ddl.Models.Compiled.Types.Names;
using TheToolsmiths.Ddl.Models.Compiled.Types.Names.Qualified.Resolution;

namespace TheToolsmiths.Ddl.Models.Compiled.Enums
{
    public class EnumStructDefinition : ITypedRootItem, IAttributableRootItem
    {
        public EnumStructDefinition(
            TypedItemName typeName,
            QualifiedItemTypeNameResolution typeNameResolution,
            IReadOnlyList<EnumStructVariantDefinition> variants,
            AttributeUseCollection attributes)
            : this(ItemId.CreateNew(), typeName, typeNameResolution, variants, attributes)
        {
        }

        public EnumStructDefinition(
            ItemId itemId,
            TypedItemName typeName,
            QualifiedItemTypeNameResolution typeNameResolution,
            IReadOnlyList<EnumStructVariantDefinition> variants,
            AttributeUseCollection attributes)
        {
            this.ItemId = itemId;
            this.TypeName = typeName;
            this.TypeNameResolution = typeNameResolution;
            this.Variants = variants;
            this.Attributes = attributes;
        }

        public IReadOnlyList<EnumStructVariantDefinition> Variants { get; }

        public AttributeUseCollection Attributes { get; }

        public ItemType ItemType => CommonItemTypes.EnumStructDefinition;

        public ItemId ItemId { get; }

        public TypedItemName TypeName { get; }

        public QualifiedItemTypeNameResolution TypeNameResolution { get; }
    }
}
