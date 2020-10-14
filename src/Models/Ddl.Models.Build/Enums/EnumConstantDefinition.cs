using TheToolsmiths.Ddl.Models.Build.AttributeUsage;
using TheToolsmiths.Ddl.Models.Build.ContentUnits;
using TheToolsmiths.Ddl.Models.Build.ContentUnits.Items;
using TheToolsmiths.Ddl.Models.Build.Literals;
using TheToolsmiths.Ddl.Models.Build.Types.Names;
using TheToolsmiths.Ddl.Models.Build.Types.Names.Qualified.Resolution;

namespace TheToolsmiths.Ddl.Models.Build.Enums
{
    public class EnumConstantDefinition : ITypedSubItem
    {
        public EnumConstantDefinition(
            SimpleTypeNameIdentifier name,
            AttributeUseCollection attributes,
            LiteralValue value)
            : this(SubItemId.CreateNew(), name, QualifiedSubItemTypeNameResolution.Unresolved, attributes, value)
        {
        }

        public EnumConstantDefinition(
            SubItemId subItemId,
            SimpleTypeNameIdentifier name,
            QualifiedSubItemTypeNameResolution typeNameResolution,
            AttributeUseCollection attributes,
            LiteralValue value)
        {
            this.SubItemId = subItemId;
            this.Name = name;
            this.TypeNameResolution = typeNameResolution;
            this.Attributes = attributes;
            this.Value = value;
        }

        public SimpleTypeNameIdentifier Name { get; }

        public AttributeUseCollection Attributes { get; }

        public LiteralValue Value { get; }

        public SubItemId SubItemId { get; }

        public QualifiedSubItemTypeNameResolution TypeNameResolution { get; }
    }
}
