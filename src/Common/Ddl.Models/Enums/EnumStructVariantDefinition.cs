using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Models.Structs.Content;
using TheToolsmiths.Ddl.Models.Types.Names;

namespace TheToolsmiths.Ddl.Models.Enums
{
    public class EnumStructVariantDefinition
    {
        public EnumStructVariantDefinition(SimpleTypeNameIdentifier variantName, StructDefinitionContent content)
            : this(SubItemId.CreateNew(), variantName, content)
        {
        }

        public EnumStructVariantDefinition(
            in SubItemId variantId,
            SimpleTypeNameIdentifier variantName,
            StructDefinitionContent content)
        {
            this.VariantId = variantId;
            this.VariantName = variantName;
            this.Content = content;
        }

        public SimpleTypeNameIdentifier VariantName { get; }

        public StructDefinitionContent Content { get; }

        public SubItemId VariantId { get; }
    }
}
