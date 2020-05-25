using System;
using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Names;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.TypePaths.Identifiers;
using TheToolsmiths.Ddl.Parser.Models.Identifiers;
using TheToolsmiths.Ddl.Parser.Models.TypePaths.Namespaces;
using TheToolsmiths.Ddl.Parser.Models.TypePaths.References;

namespace TheToolsmiths.Ddl.Parser.Common
{
    public static class TypeReferencePathBuilder
    {
        public static TypeReferencePath FromTypeName(TypeName typeName)
        {
            var pathParts = new List<TypeReferencePathPart>();

            TypeReferencePathPart pathPart = typeName switch
            {
                GenericTypeName genericType => new GenericReferencePathPart(
                    genericType.Name,
                    genericType.TypeParameters.Count),
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

        public static TypeReferencePath CreateFromIdentifierPath(TypeIdentifierPath lookupPath)
        {
            var pathParts = lookupPath.PathParts.Select(CreateFromIdentifierPart).ToList();

            return new TypeReferencePath(lookupPath.IsRooted, pathParts);

            static TypeReferencePathPart CreateFromIdentifierPart(TypeIdentifierPathPart identifierPart)
            {
                return identifierPart switch
                {
                    GenericIdentifierPathPart genericPart => new GenericReferencePathPart(
                        genericPart.Name,
                        genericPart.GenericParameters.Count),
                    SimpleIdentifierPathPart simplePart => new SimpleReferencePathPart(simplePart.Name),
                    _ => throw new ArgumentOutOfRangeException(nameof(identifierPart))
                };
            }
        }
    }
}
