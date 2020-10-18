namespace TheToolsmiths.Ddl.Models.Compiled.Namespaces.Paths
{
    public static class QualifiedNamespacePathComparer
    {
        public static bool StartsWithNamespace(QualifiedNamespacePath namespacePath, QualifiedNamespacePath baseNamespace)
        {
            if (namespacePath.Identifiers.Length < baseNamespace.Identifiers.Length)
            {
                return false;
            }

            for (int i = 0; i < baseNamespace.Identifiers.Length; i++)
            {
                var prefixPart = baseNamespace.Identifiers[i];
                var namespacePart = namespacePath.Identifiers[i];

                if (prefixPart != namespacePart)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsParentOf(QualifiedNamespacePath parentPath, QualifiedNamespacePath childPath)
        {
            if (parentPath.Identifiers.Length > childPath.Identifiers.Length)
            {
                return false;
            }

            for (int i = 0; i < parentPath.Identifiers.Length; i++)
            {
                string parentPart = parentPath.Identifiers[i];
                string childPart = childPath.Identifiers[i];

                if (parentPart != childPart)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
