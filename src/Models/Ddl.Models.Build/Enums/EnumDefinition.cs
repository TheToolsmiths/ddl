using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.AttributeUsage;
using TheToolsmiths.Ddl.Models.Build.ContentUnits;
using TheToolsmiths.Ddl.Models.Build.ContentUnits.Items;
using TheToolsmiths.Ddl.Models.Build.EntryTypes;
using TheToolsmiths.Ddl.Models.Build.Types.Names;
using TheToolsmiths.Ddl.Models.Build.Types.Names.Qualified.Resolution;

namespace TheToolsmiths.Ddl.Models.Build.Enums
{
    public class EnumDefinition : ITypedRootItem, IAttributableRootItem
    {
        public EnumDefinition(
            ItemId itemId,
            TypedItemName typeName,
            QualifiedItemTypeNameResolution typeNameResolution,
            IReadOnlyList<EnumConstantDefinition> constants,
            AttributeUseCollection attributes)
        {
            this.TypeName = typeName;
            this.TypeNameResolution = typeNameResolution;
            this.Constants = constants;
            this.Attributes = attributes;
            this.ItemId = itemId;
        }

        public EnumDefinition(
            TypedItemName typeName,
            QualifiedItemTypeNameResolution typeNameResolution,
            IReadOnlyList<EnumConstantDefinition> constants,
            AttributeUseCollection attributes)
            : this(ItemId.CreateNew(), typeName, typeNameResolution, constants, attributes)
        {
        }

        public TypedItemName TypeName { get; }

        public QualifiedItemTypeNameResolution TypeNameResolution { get; }

        public IReadOnlyList<EnumConstantDefinition> Constants { get; }

        public AttributeUseCollection Attributes { get; }

        public ItemType ItemType => CommonItemTypes.EnumDefinition;

        public ItemId ItemId { get; }
    }
}
