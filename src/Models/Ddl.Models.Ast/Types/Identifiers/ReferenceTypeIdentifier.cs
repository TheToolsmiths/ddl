namespace TheToolsmiths.Ddl.Models.Ast.Types.Identifiers
{
    public class ReferenceTypeIdentifier : ITypeIdentifier, IModifiableTypeIdentifier
    {
        public ReferenceTypeIdentifier(IReferenceableTypeIdentifier typeIdentifier, ReferenceKind referenceKind)
        {
            this.TypeIdentifier = typeIdentifier;
            this.ReferenceKind = referenceKind;
        }

        public IReferenceableTypeIdentifier TypeIdentifier { get; }

        public ReferenceKind ReferenceKind { get; }

        public override string ToString()
        {
            return $"{this.ReferenceKind} {this.TypeIdentifier}";
        }
    }
}
