using TheToolsmiths.Ddl.Models.Build.AttributeUsage;
using TheToolsmiths.Ddl.Models.Build.ContentUnits;
using TheToolsmiths.Ddl.Models.Build.ContentUnits.Items;
using TheToolsmiths.Ddl.Models.Build.Structs.Content;
using TheToolsmiths.Ddl.Models.Build.Types.Names;
using TheToolsmiths.Ddl.Models.Build.Types.Names.Qualified.Resolution;

namespace TheToolsmiths.Ddl.Models.Build.Enums
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
