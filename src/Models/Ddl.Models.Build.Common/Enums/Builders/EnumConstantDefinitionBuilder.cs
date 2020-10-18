using System;
using TheToolsmiths.Ddl.Models.Build.AttributeUsage;
using TheToolsmiths.Ddl.Models.Items;
using TheToolsmiths.Ddl.Models.Literals;
using TheToolsmiths.Ddl.Models.Types.Names;

namespace TheToolsmiths.Ddl.Models.Build.Enums.Builders
{
    public class EnumConstantDefinitionBuilder
    {
        public EnumConstantDefinitionBuilder(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public LiteralValue? Value { get; set; }

        public EnumConstantDefinitionBuilder WithName(string name)
        {
            this.Name = name;

            return this;
        }
        public EnumConstantDefinitionBuilder WithValue(LiteralValue value)
        {
            this.Value = value;

            return this;
        }

        public EnumConstantDefinition Build()
        {
            string name = this.Name ?? throw new NotImplementedException();
            LiteralValue value = this.Value ?? throw new NotImplementedException();

            var typeName = new SimpleTypeNameIdentifier(name);

            var attributes = AttributeUseCollection.Empty;

            SubItemId subItemId = default;

            throw new NotImplementedException();

            //return new EnumConstantDefinition(subItemId, typeName, attributes, value);
        }
    }
}
