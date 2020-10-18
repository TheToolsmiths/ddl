using System;

namespace TheToolsmiths.Ddl.Models.Build.Namespaces.Paths
{
    public static class RootNamespacePathComparer
    {
        public static bool StartsWithNamespace(RootNamespacePath namespacePath, RootNamespacePath baseNamespace)
        {
            if (namespacePath.IsRooted == false)
            {
                throw new NotImplementedException();
            }

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

        public static bool IsParentOf(RootNamespacePath parentPath, RootNamespacePath childPath)
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
