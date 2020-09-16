using System;

namespace TheToolsmiths.Ddl.Models.Types.TypePaths.Namespaces
{
    public static class NamespacePathComparer
    {
        public static bool StartsWithNamespace(RootNamespacePath namespacePath, RootNamespacePath baseNamespace)
        {
            if (namespacePath.IsRooted == false)
            {
                throw new NotImplementedException();
            }

            if (namespacePath.Identifiers.Count < baseNamespace.Identifiers.Count)
            {
                return false;
            }

            for (int i = 0; i < baseNamespace.Identifiers.Count; i++)
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
    }
}
