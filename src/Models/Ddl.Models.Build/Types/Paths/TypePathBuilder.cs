using System;
using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Models.Build.Namespaces.Paths;

namespace TheToolsmiths.Ddl.Models.Build.Types.Paths
{
    public static class TypePathBuilder
    {
        public static RootTypePath RootToNamespace(
            TypePath typePath,
            RootNamespacePath namespacePath)
        {
            if (typePath.IsRooted)
            {
                throw new ArgumentException(nameof(typePath));
            }

            var pathParts = new List<TypePathPart>();

            pathParts.AddRange(namespacePath.Identifiers.Select(i => new SimplePathPart(i)));

            pathParts.AddRange(typePath.PathParts);

            return TypePath.CreateRootedFromParts(pathParts);
        }

        public static RootTypePath TryRootToNamespace(
            TypePath typePath,
            RootNamespacePath namespacePath)
        {
            if (typePath is RootTypePath rootedTypeReferencePath)
            {
                return rootedTypeReferencePath;
            }

            return RootToNamespace(typePath, namespacePath);
        }
    }
}
