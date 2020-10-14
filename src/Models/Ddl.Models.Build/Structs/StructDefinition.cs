using TheToolsmiths.Ddl.Models.Build.AttributeUsage;
using TheToolsmiths.Ddl.Models.Build.ContentUnits;
using TheToolsmiths.Ddl.Models.Build.ContentUnits.Items;
using TheToolsmiths.Ddl.Models.Build.EntryTypes;
using TheToolsmiths.Ddl.Models.Build.Structs.Content;
using TheToolsmiths.Ddl.Models.Build.Types.Names;
using TheToolsmiths.Ddl.Models.Build.Types.Names.Qualified.Resolution;

namespace TheToolsmiths.Ddl.Models.Build.Structs
{
    public class StructDefinition : ITypedRootItem, IAttributableRootItem
    {
        public StructDefinition(
            ItemId itemId,
            TypedItemName typeName,
            QualifiedItemTypeNameResolution typeNameResolution,
            StructDefinitionContent content,
            AttributeUseCollection attributes)
        {
            this.TypeName = typeName;
            this.TypeNameResolution = typeNameResolution;
            this.Content = content;
            this.Attributes = attributes;
            this.ItemId = itemId;
        }

        public StructDefinition(
            TypedItemName typeName,
            QualifiedItemTypeNameResolution typeNameResolution,
            StructDefinitionContent content,
            AttributeUseCollection attributes)
            : this(ItemId.CreateNew(), typeName, typeNameResolution, content, attributes)
        {
        }

        public StructDefinition(TypedItemName typeName, StructDefinitionContent content)
            : this(ItemId.CreateNew(), typeName, QualifiedItemTypeNameResolution.Unresolved, content, AttributeUseCollection.Empty)
        {
        }

        public TypedItemName TypeName { get; }

        public QualifiedItemTypeNameResolution TypeNameResolution { get; }

        public StructDefinitionContent Content { get; }

        public AttributeUseCollection Attributes { get; }

        public ItemType ItemType => CommonItemTypes.StructDefinition;

        public ItemId ItemId { get; }
    }
}
