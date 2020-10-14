using System;
using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Models.Build.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Models.Build.Types.TypePaths.References
{
    public static class TypeReferencePathBuilder
    {
        public static RootTypeReferencePath RootToNamespace(
            TypeReferencePath referencePath,
            RootNamespacePath namespacePath)
        {
            if (referencePath.IsRooted)
            {
                throw new ArgumentException(nameof(referencePath));
            }

            var pathParts = new List<TypeReferencePathPart>();

            pathParts.AddRange(namespacePath.Identifiers.Select(i => new SimpleReferencePathPart(i)));

            pathParts.AddRange(referencePath.PathParts);

            return TypeReferencePath.CreateRootedFromParts(pathParts);
        }

        public static RootTypeReferencePath TryRootToNamespace(
            TypeReferencePath referencePath,
            RootNamespacePath namespacePath)
        {
            if (referencePath is RootTypeReferencePath rootedTypeReferencePath)
            {
                return rootedTypeReferencePath;
            }

            return RootToNamespace(referencePath, namespacePath);
        }
    }
}
