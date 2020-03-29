namespace TheToolsmiths.Ddl.Models.Types
{
    public class ReferenceTypeIdentifier : ITypeIdentifier
    {
        public ReferenceTypeIdentifier(ITypeIdentifier typeIdentifier, ReferenceKind referenceKind)
        {
            this.TypeIdentifier = typeIdentifier;
            this.ReferenceKind = referenceKind;
        }

        public TypeIdentifierKind Kind => TypeIdentifierKind.ReferenceType;

        public ITypeIdentifier TypeIdentifier { get; }

        public ReferenceKind ReferenceKind { get; }


        public override string ToString()
        {
            return $"{this.ReferenceKind} {this.TypeIdentifier}";
        }
    }
}
