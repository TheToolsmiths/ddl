namespace TheToolsmiths.Ddl.Parser.Packager.ContentUnits
{
    public class PackageContentUnitScope
    {
        public PackageContentUnitScope(PackageContentUnitScopeContent scopeContent)
        {
            this.ScopeContent = scopeContent;
        }

        public PackageContentUnitScopeContent ScopeContent { get; }
    }
}
