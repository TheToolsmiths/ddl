namespace TheToolsmiths.Ddl.Models.Types.Usage.Locality
{
    public class TypeUseLocality
    {
        private TypeUseLocality(LocalityReferenceKind referenceKind)
        {
            this.LocalityKind = LocalityKind.Reference;
            this.ReferenceKind = referenceKind;
        }

        private TypeUseLocality(LocalityKind localityKind)
        {
            this.LocalityKind = localityKind;
            this.ReferenceKind = LocalityReferenceKind.Owns;
        }

        public LocalityKind LocalityKind { get; }

        public LocalityReferenceKind ReferenceKind { get; }

        public static TypeUseLocality Local { get; } = new TypeUseLocality(LocalityKind.Local);

        public static TypeUseLocality OwnsReference { get; } = new TypeUseLocality(LocalityReferenceKind.Owns);

        public static TypeUseLocality HandleReference { get; } = new TypeUseLocality(LocalityReferenceKind.Handle);

        public static TypeUseLocality RefReference { get; } = new TypeUseLocality(LocalityReferenceKind.Reference);
    }
}
