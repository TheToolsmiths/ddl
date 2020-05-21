namespace TheToolsmiths.Ddl.Parser.Ast.Models.Types.Identifiers
{
    public class ConstantTypeIdentifier : IModifierTypeIdentifier
    {
        public ConstantTypeIdentifier(ITypeIdentifier typeIdentifier)
        {
            this.TypeIdentifier = typeIdentifier;
        }

        public TypeIdentifierKind Kind => TypeIdentifierKind.ReferenceType;

        public ITypeIdentifier TypeIdentifier { get; }

        public ModifierTypeKind ModifierKind => ModifierTypeKind.Constant;

        public override string ToString()
        {
            return $"const {this.TypeIdentifier}";
        }
    }
}
