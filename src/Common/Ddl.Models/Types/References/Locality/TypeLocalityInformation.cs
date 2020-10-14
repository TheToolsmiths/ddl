namespace TheToolsmiths.Ddl.Models.Types.References.Locality
{
    public class TypeLocalityInformation
    {
        private TypeLocalityInformation(LocalityReferenceKind referenceKind)
        {
            this.LocalityKind = LocalityKind.Reference;
            this.ReferenceKind = referenceKind;
        }

        private TypeLocalityInformation(LocalityKind localityKind)
        {
            this.LocalityKind = localityKind;
            this.ReferenceKind = LocalityReferenceKind.Owns;
        }

        public LocalityKind LocalityKind { get; }

        public LocalityReferenceKind ReferenceKind { get; }

        public static TypeLocalityInformation Local { get; } = new TypeLocalityInformation(LocalityKind.Local);

        public static TypeLocalityInformation OwnsReference { get; } = new TypeLocalityInformation(LocalityReferenceKind.Owns);

        public static TypeLocalityInformation HandleReference { get; } = new TypeLocalityInformation(LocalityReferenceKind.Handle);

        public static TypeLocalityInformation RefReference { get; } = new TypeLocalityInformation(LocalityReferenceKind.Reference);
    }
}
