using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Ast.Models.Identifiers;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Identifiers;
using TheToolsmiths.Ddl.Parser.Ast.Models.Values;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Structs
{
    public class FieldDefinition : IStructDefinitionItem
    {
        public FieldDefinition(
            Identifier name,
            ITypeIdentifier fieldType,
            ValueInitialization initialization,
            IReadOnlyList<IAstAttributeUse> attributes)
        {
            this.Attributes = attributes;
            this.Initialization = initialization;
            this.FieldType = fieldType;
            this.Name = name;
        }

        public Identifier Name { get; }

        public ITypeIdentifier FieldType { get; }

        public IReadOnlyList<IAstAttributeUse> Attributes { get; }

        public ValueInitialization Initialization { get; }

        public StructDefinitionItemType ItemType => StructDefinitionItemType.FieldDefinition;
    }
}
