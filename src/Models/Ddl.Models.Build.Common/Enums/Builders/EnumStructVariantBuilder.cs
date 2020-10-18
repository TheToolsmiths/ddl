using System;
using TheToolsmiths.Ddl.Models.Build.AttributeUsage;
using TheToolsmiths.Ddl.Models.Build.Structs.Content.Builders;
using TheToolsmiths.Ddl.Models.Types.Names;

namespace TheToolsmiths.Ddl.Models.Build.Enums.Builders
{
    public class EnumStructVariantBuilder
    {
        public EnumStructVariantBuilder(string variantName)
        {
            this.VariantName = variantName;
            this.Content = new StructContentBuilder();
        }

        public string VariantName { get; }

        public StructContentBuilder Content { get; }

        public EnumStructVariantDefinition Build()
        {
            var variantName = new SimpleTypeNameIdentifier(this.VariantName);

            var content = this.Content.Build();

            var attributes = AttributeUseCollection.Empty;

            throw new NotImplementedException();

            //SubItemId subItemId;
            //return new EnumStructVariantDefinition(subItemId, variantName, attributes, content);
        }
    }
}
