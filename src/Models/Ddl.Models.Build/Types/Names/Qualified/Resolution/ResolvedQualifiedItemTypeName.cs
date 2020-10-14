namespace TheToolsmiths.Ddl.Models.Build.Types.Names.Qualified.Resolution
{
    public class ResolvedQualifiedItemTypeName : QualifiedItemTypeNameResolution
    {
        public ResolvedQualifiedItemTypeName(QualifiedItemTypeName typeName)
            : base(QualifiedTypeNameResolutionKind.Resolved)
        {
            this.TypeName = typeName;
        }

        public QualifiedItemTypeName TypeName { get; }

        public override string ToString()
        {
            return $"Item > {this.TypeName}";
        }
    }
}
