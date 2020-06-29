using System;
using TheToolsmiths.Ddl.Models.Literals;

namespace TheToolsmiths.Ddl.Models.Enums.Builders
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

            return new EnumConstantDefinition(name, value);
        }
    }
}