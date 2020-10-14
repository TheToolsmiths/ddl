using TheToolsmiths.Ddl.Models.Compiled.AttributeUsage;
using TheToolsmiths.Ddl.Models.Compiled.Structs.Content.Builders;
using TheToolsmiths.Ddl.Models.Compiled.Types.Names;

namespace TheToolsmiths.Ddl.Models.Compiled.Enums.Builders
{
    public class EnumStructVariantBuilder
    {
        public EnumStructVariantBuilder(string variantName)
        {
            this.VariantName = variantName;
            this.Content = new StructDefinitionContentBuilder();
        }

        public string VariantName { get; }

        public StructDefinitionContentBuilder Content { get; }

        public EnumStructVariantDefinition Build()
        {
            var variantName = new SimpleTypeNameIdentifier(this.VariantName);

            var content = this.Content.Build();

            var attributes = AttributeUseCollection.Empty;
            return new EnumStructVariantDefinition(variantName, attributes, content);
        }
    }
}
