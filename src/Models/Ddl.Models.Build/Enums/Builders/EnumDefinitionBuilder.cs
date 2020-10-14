using System;
using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Models.Build.AttributeUsage;
using TheToolsmiths.Ddl.Models.Build.Types.Names;
using TheToolsmiths.Ddl.Models.Build.Types.Names.Qualified.Resolution;

namespace TheToolsmiths.Ddl.Models.Build.Enums.Builders
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

            var typeNameResolution = QualifiedItemTypeNameResolution.Unresolved;

            return new EnumDefinition(typeName, typeNameResolution, variants, AttributeUseCollection.Empty);
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
