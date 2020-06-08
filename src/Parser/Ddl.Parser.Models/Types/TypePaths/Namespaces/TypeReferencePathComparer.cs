namespace TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.Namespaces
{
    public static class NamespacePathComparer
    {
        public static bool StartsWithRootedNamespace(NamespacePath namespacePath, NamespacePath prefixPath)
        {
            if (namespacePath.IsRooted == false
            || prefixPath.IsRooted == false)
            {
                return false;
            }

            if (namespacePath.Identifiers.Count < prefixPath.Identifiers.Count)
            {
                return false;
            }

            for (int i = 0; i < prefixPath.Identifiers.Count; i++)
            {
                var prefixPart = prefixPath.Identifiers[i];
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
