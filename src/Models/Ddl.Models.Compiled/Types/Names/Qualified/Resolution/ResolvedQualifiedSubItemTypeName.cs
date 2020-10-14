namespace TheToolsmiths.Ddl.Models.Compiled.Types.Names.Qualified.Resolution
{
    public class ResolvedQualifiedSubItemTypeName : QualifiedSubItemTypeNameResolution
    {
        public ResolvedQualifiedSubItemTypeName(QualifiedSubItemTypeName typeName)
            : base(QualifiedTypeNameResolutionKind.Resolved)
        {
            this.TypeName = typeName;
        }

        public QualifiedSubItemTypeName TypeName { get; }

        public override string ToString()
        {
            return $"SubItem > {this.TypeName}";
        }
    }
}
