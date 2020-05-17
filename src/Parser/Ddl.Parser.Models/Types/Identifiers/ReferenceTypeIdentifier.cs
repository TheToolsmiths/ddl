namespace TheToolsmiths.Ddl.Parser.Models.Types.Identifiers
{
    public class ReferenceTypeIdentifier : ITypeIdentifier
    {
        public ReferenceTypeIdentifier(ITypeIdentifier typeIdentifier, ReferenceTypeKind referenceKind)
        {
            this.TypeIdentifier = typeIdentifier;
            this.ReferenceKind = referenceKind;
        }

        public TypeIdentifierKind Kind => TypeIdentifierKind.ReferenceType;

        public ITypeIdentifier TypeIdentifier { get; }

        public ReferenceTypeKind ReferenceKind { get; }

        public override string ToString()
        {
            return $"{this.ReferenceKind} {this.TypeIdentifier}";
        }
    }
}
