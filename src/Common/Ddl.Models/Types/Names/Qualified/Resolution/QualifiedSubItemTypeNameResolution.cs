namespace TheToolsmiths.Ddl.Models.Types.Names.Qualified.Resolution
{
    public abstract class QualifiedSubItemTypeNameResolution : QualifiedTypeNameResolution
    {
        protected QualifiedSubItemTypeNameResolution(QualifiedTypeNameResolutionKind resolutionKind) : base(resolutionKind)
        {
        }

        public static QualifiedSubItemTypeNameResolution Unresolved { get; } = new UnresolvedQualifiedSubItemTypeName();
    }
}
