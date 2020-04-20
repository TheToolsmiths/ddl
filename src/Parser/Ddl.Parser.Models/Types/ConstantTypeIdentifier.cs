namespace TheToolsmiths.Ddl.Parser.Models.Types
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
