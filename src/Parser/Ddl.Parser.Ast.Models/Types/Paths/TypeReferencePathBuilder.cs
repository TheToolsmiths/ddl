using System;
using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Parser.Ast.Models.Identifiers;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Names;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Namespaces;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Types.Paths
{
    public static class TypeReferencePathBuilder
    {
        public static TypeReferencePath FromTypeName(ITypeName typeName)
        {
            var pathParts = new List<TypeReferencePathPart>();

            TypeReferencePathPart pathPart = typeName switch
            {
                GenericTypeName genericType => new GenericReferencePathPart(
                    genericType.Name,
                    genericType.TypeArgumentList.Count),
                SimpleTypeName simpleType => new SimpleReferencePathPart(simpleType.Name),
                _ => throw new ArgumentOutOfRangeException(nameof(typeName))
            };

            pathParts.Add(pathPart);

            return TypeReferencePath.CreateFromParts(pathParts);
        }

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

        public static TypeReferencePath AppendIdentifier(
            TypeReferencePath referencePath,
            Identifier identifier)
        {
            throw new NotImplementedException();
        }
    }
}
