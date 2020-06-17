using System;
using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Models.Types.TypePaths.Namespaces;
using TheToolsmiths.Ddl.Models.Types.TypePaths.References;

namespace TheToolsmiths.Ddl.TypeResolution
{
    public static class TypeReferencePathBuilder
    {
        public static TypeReferencePath PrependNamespace(
            TypeReferencePath referencePath,
            NamespacePath namespacePath)
        {
            if (referencePath.IsRooted)
            {
                throw new ArgumentException(nameof(referencePath));
            }

            var pathParts = new List<TypeReferencePathPart>();

            pathParts.AddRange(namespacePath.Identifiers.Select(i => new SimpleReferencePathPart(i)));

            pathParts.AddRange(referencePath.PathParts);

            return namespacePath.IsRooted ? TypeReferencePath.CreateRootedFromParts(pathParts) : TypeReferencePath.CreateFromParts(pathParts);
        }
    }
}
