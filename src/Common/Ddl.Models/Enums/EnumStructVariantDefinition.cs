using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Models.Structs.Content;
using TheToolsmiths.Ddl.Models.Types.Names;
using TheToolsmiths.Ddl.Models.Types.Names.Qualified.Resolution;

namespace TheToolsmiths.Ddl.Models.Enums
{
    public class EnumStructVariantDefinition : ITypedSubItem
    {
        public EnumStructVariantDefinition(
            SimpleTypeNameIdentifier name,
            QualifiedSubItemTypeNameResolution typeNameResolution,
            AttributeUseCollection attributes,
            StructDefinitionContent content)
            : this(SubItemId.CreateNew(), name, typeNameResolution, attributes, content)
        {
        }

        public EnumStructVariantDefinition(
            SimpleTypeNameIdentifier name,
            AttributeUseCollection attributes,
            StructDefinitionContent content)
            : this(SubItemId.CreateNew(), name, QualifiedSubItemTypeNameResolution.Unresolved, attributes, content)
        {
        }

        public EnumStructVariantDefinition(
            SubItemId subItemId,
            SimpleTypeNameIdentifier name,
            QualifiedSubItemTypeNameResolution typeNameResolution,
            AttributeUseCollection attributes,
            StructDefinitionContent content)
        {
            this.SubItemId = subItemId;
            this.Name = name;
            this.TypeNameResolution = typeNameResolution;
            this.Attributes = attributes;
            this.Content = content;
        }

        public SimpleTypeNameIdentifier Name { get; }

        public AttributeUseCollection Attributes { get; }

        public StructDefinitionContent Content { get; }

        public SubItemId SubItemId { get; }

        public QualifiedSubItemTypeNameResolution TypeNameResolution { get; }
    }
}
