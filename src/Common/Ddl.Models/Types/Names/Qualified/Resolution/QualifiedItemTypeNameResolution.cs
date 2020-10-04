namespace TheToolsmiths.Ddl.Models.Types.Names.Qualified.Resolution
{
    public abstract class QualifiedItemTypeNameResolution : QualifiedTypeNameResolution
    {
        protected QualifiedItemTypeNameResolution(QualifiedTypeNameResolutionKind resolutionKind) : base(resolutionKind)
        {
        }

        public static QualifiedItemTypeNameResolution Unresolved { get; } = new UnresolvedQualifiedItemTypeName();
    }
}