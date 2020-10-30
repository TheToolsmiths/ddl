namespace TheToolsmiths.Ddl.Models.Compiled.Namespaces.Paths
{
    public static class QualifiedNamespacePathExtensions
    {
        public static bool IsParentOf(this QualifiedNamespacePath parentPath, QualifiedNamespacePath childPath)
        {
            return QualifiedNamespacePathComparer.IsParentOf(parentPath, childPath);
        }
    }
}
