using System;
using TheToolsmiths.Ddl.Models.Compiled.AttributeUsage;
using TheToolsmiths.Ddl.Models.Compiled.Literals;
using TheToolsmiths.Ddl.Models.Compiled.Types.Names;

namespace TheToolsmiths.Ddl.Models.Compiled.Enums.Builders
{
    public class EnumConstantDefinitionBuilder
    {
        public EnumConstantDefinitionBuilder(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public LiteralValue Value { get; set; } = new DefaultLiteral();

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

            return new EnumConstantDefinition(typeName, attributes, value);
        }
    }
}
