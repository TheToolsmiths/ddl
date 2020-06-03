namespace TheToolsmiths.Ddl.Parser.Models.Types.References
{
    public class LocalityInformation
    {
        private LocalityInformation(LocalityReferenceKind owns)
        {
            this.LocalityKind = LocalityKind.Reference;
            this.ReferenceKind = owns;
        }

        private LocalityInformation(LocalityKind localityKind)
        {
            this.LocalityKind = localityKind;
        }

        public LocalityKind LocalityKind { get; }

        public LocalityReferenceKind ReferenceKind { get; }

        public static LocalityInformation Local { get; } = new LocalityInformation(LocalityKind.Local);

        public static LocalityInformation OwnsReference { get; } = new LocalityInformation(LocalityReferenceKind.Owns);

        public static LocalityInformation HandleReference { get; } =
            new LocalityInformation(LocalityReferenceKind.Handle);

        public static LocalityInformation RefReference { get; } =
            new LocalityInformation(LocalityReferenceKind.Reference);
    }
}
