using System;
using System.Collections.Generic;
using System.Linq;

using TheToolsmiths.Ddl.Parser.Ast.Models.Types.TypePaths.Identifiers;
using TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.Namespaces;
using TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.References;

namespace TheToolsmiths.Ddl.Resolve.Common.TypeHelpers
{
    public static class ResolveTypeReferencePathBuilder
    {
        // TODO: Delete
        //public static TypeReferencePath FromTypeName(TypeName typeName)
        //{
        //    var pathParts = new List<TypeReferencePathPart>();

        //    TypeReferencePathPart pathPart = typeName switch
        //    {
        //        GenericTypeName genericType => throw new NotImplementedException() /*new GenericReferencePathPart(
        //            genericType.Name,
        //            genericType.TypeParameters.Count)*/,
        //        SimpleTypeName simpleType => new SimpleReferencePathPart(simpleType.Name),
        //        _ => throw new ArgumentOutOfRangeException(nameof(typeName))
        //    };

        //    pathParts.Add(pathPart);

        //    return TypeReferencePath.CreateFromParts(pathParts);
        //}

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
            string identifier)
        {
            var pathParts = referencePath.PathParts.ToList();

            pathParts.Add(new SimpleReferencePathPart(identifier));

            return referencePath.IsRooted
                ? TypeReferencePath.CreateRootedFromParts(pathParts)
                : TypeReferencePath.CreateFromParts(pathParts);
        }

        //public static TypeReferencePath CreateFromIdentifierPath(TypeIdentifierPath lookupPath)
        //{
        //    var pathParts = lookupPath.PathParts.Select(CreateFromIdentifierPart).ToList();

        //    return new TypeReferencePath(lookupPath.IsRooted, pathParts);

        //    static TypeReferencePathPart CreateFromIdentifierPart(TypeIdentifierPathPart identifierPart)
        //    {
        //        return identifierPart switch
        //        {
        //            GenericIdentifierPathPart genericPart => throw new NotImplementedException() /*new GenericReferencePathPart(
        //                genericPart.Name,
        //                genericPart.GenericParameters.Count)*/,
        //            SimpleIdentifierPathPart simplePart => new SimpleReferencePathPart(simplePart.Name.Text),
        //            _ => throw new ArgumentOutOfRangeException(nameof(identifierPart))
        //        };
        //    }
        //}
    }
}
