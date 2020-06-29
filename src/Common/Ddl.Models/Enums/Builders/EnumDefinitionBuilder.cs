using System;
using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Models.Types.Names;

namespace TheToolsmiths.Ddl.Models.Enums.Builders
{
    public class EnumDefinitionBuilder
    {
        public EnumDefinitionBuilder()
        {
            this.Constants = new List<EnumConstantDefinitionBuilder>();
        }

        public SimpleTypeNameIdentifier? TypeName { get; set; }

        public List<EnumConstantDefinitionBuilder> Constants { get; }

        public EnumDefinition Build()
        {
            var nameIdentifier = this.TypeName ?? throw new NotImplementedException();
            var typeName = new TypedItemName(nameIdentifier);

            var variants = this.Constants.Select(v => v.Build()).ToList();

            return new EnumDefinition(typeName, variants);
        }

        public EnumConstantDefinitionBuilder WithConstant(string constantName)
        {
            var constantBuilder = new EnumConstantDefinitionBuilder(constantName);

            this.Constants.Add(constantBuilder);

            return constantBuilder;
        }

        public EnumDefinitionBuilder WithSimpleTypeName(string typeName)
        {
            this.TypeName = new SimpleTypeNameIdentifier(typeName);

            return this;
        }
    }
}
