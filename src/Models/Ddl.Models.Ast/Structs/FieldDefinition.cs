using TheToolsmiths.Ddl.Models.Ast.AttributeUsage;
using TheToolsmiths.Ddl.Models.Ast.Identifiers;
using TheToolsmiths.Ddl.Models.Ast.Types.Identifiers;
using TheToolsmiths.Ddl.Models.Ast.Values;

namespace TheToolsmiths.Ddl.Models.Ast.Structs
{
    public class FieldDefinition : IStructDefinitionItem
    {
        public FieldDefinition(
            Identifier name,
            ITypeIdentifier fieldType,
            ValueInitialization initialization,
            AstAttributeUseCollection attributes)
        {
            this.Attributes = attributes;
            this.Initialization = initialization;
            this.FieldType = fieldType;
            this.Name = name;
        }

        public Identifier Name { get; }

        public ITypeIdentifier FieldType { get; }

        public AstAttributeUseCollection Attributes { get; }

        public ValueInitialization Initialization { get; }

        public StructDefinitionItemType ItemType => StructDefinitionItemType.FieldDefinition;
    }
}
