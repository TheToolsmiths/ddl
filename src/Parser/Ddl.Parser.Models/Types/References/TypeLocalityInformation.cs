namespace TheToolsmiths.Ddl.Parser.Models.Types.References
{
    public class TypeLocalityInformation
    {
        private TypeLocalityInformation(LocalityReferenceKind owns)
        {
            this.LocalityKind = LocalityKind.Reference;
            this.ReferenceKind = owns;
        }

        private TypeLocalityInformation(LocalityKind localityKind)
        {
            this.LocalityKind = localityKind;
        }

        public LocalityKind LocalityKind { get; }

        public LocalityReferenceKind ReferenceKind { get; }

        public static TypeLocalityInformation Local { get; } = new TypeLocalityInformation(LocalityKind.Local);

        public static TypeLocalityInformation OwnsReference { get; } = new TypeLocalityInformation(LocalityReferenceKind.Owns);

        public static TypeLocalityInformation HandleReference { get; } =
            new TypeLocalityInformation(LocalityReferenceKind.Handle);

        public static TypeLocalityInformation RefReference { get; } =
            new TypeLocalityInformation(LocalityReferenceKind.Reference);
    }
}
