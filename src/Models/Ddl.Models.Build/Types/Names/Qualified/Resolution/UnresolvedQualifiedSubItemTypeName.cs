namespace TheToolsmiths.Ddl.Models.Build.Types.Names.Qualified.Resolution
{
    public class UnresolvedQualifiedSubItemTypeName : QualifiedSubItemTypeNameResolution
    {
        public UnresolvedQualifiedSubItemTypeName()
            : base(QualifiedTypeNameResolutionKind.Unresolved)
        {
        }

        public override string ToString()
        {
            return "Unresolved SubItem TypeName";
        }
    }
}
