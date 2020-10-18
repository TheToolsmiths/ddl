namespace TheToolsmiths.Ddl.Models.Build.Namespaces.Paths
{
    public static class RootNamespacePathExtensions
    {
        public static bool IsParentOf(this RootNamespacePath parentPath, RootNamespacePath childPath)
        {
            return RootNamespacePathComparer.IsParentOf(parentPath, childPath);
        }
    }
}
