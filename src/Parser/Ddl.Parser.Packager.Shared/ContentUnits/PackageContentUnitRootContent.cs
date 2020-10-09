namespace TheToolsmiths.Ddl.Parser.Packager.ContentUnits
{
    public class PackageContentUnitRootContent
    {
        public PackageContentUnitRootContent(PackageContentUnitNamespace rootNamespace)
        {
            this.RootNamespace = rootNamespace;
        }

        public PackageContentUnitNamespace RootNamespace { get; }
    }
}
