namespace TheToolsmiths.Ddl.Models.Build.Types.Names.Qualified.Resolution
{
    public abstract class QualifiedTypeNameResolution
    {
        protected QualifiedTypeNameResolution(QualifiedTypeNameResolutionKind resolutionKind)
        {
            this.ResolutionKind = resolutionKind;
        }

        public QualifiedTypeNameResolutionKind ResolutionKind { get; }

        public abstract override string ToString();
    }
}
