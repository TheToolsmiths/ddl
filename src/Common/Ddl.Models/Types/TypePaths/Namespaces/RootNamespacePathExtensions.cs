namespace TheToolsmiths.Ddl.Models.Types.TypePaths.Namespaces
{
    public static class RootNamespacePathExtensions
    {
        public static bool IsParentOf(this RootNamespacePath parentPath, RootNamespacePath childPath)
        {
            return RootNamespacePathComparer.IsParentOf(parentPath, childPath);
        }
    }
}
