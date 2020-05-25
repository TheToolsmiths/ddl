using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

using TheToolsmiths.Ddl.Parser.Ast.Models.Types.TypePaths.Identifiers;
using TheToolsmiths.Ddl.Parser.Models.TypePaths.Identifiers;

namespace TheToolsmiths.Ddl.Resolve.SecondPhase.TypePathHelpers
{
    public static class TypePathConverter
    {
        public static ResolvedTypeIdentifierPath ConvertToResolvedPath(TypeIdentifierPath typePath)
        {
            var pathParts = new List<ResolvedTypeIdentifierPathPart>();

            foreach (var identifierPathPart in typePath.PathParts)
            {
                var pathPart = ConvertToResolvedPathPart(identifierPathPart);

                pathParts.Add(pathPart);
            }

            return typePath.IsRooted
                ? ResolvedTypeIdentifierPath.CreateRootedFromParts(pathParts)
                : ResolvedTypeIdentifierPath.CreateFromParts(pathParts);
        }

        private static ResolvedTypeIdentifierPathPart ConvertToResolvedPathPart(
            TypeIdentifierPathPart identifierPathPart)
        {
            return identifierPathPart switch
            {
                GenericIdentifierPathPart identifier => ConvertToGenericPathPart(identifier),
                SimpleIdentifierPathPart identifier => ConvertToSimplePathPart(identifier),
                _ => throw new ArgumentOutOfRangeException(nameof(identifierPathPart))
            };
        }

        private static ResolvedTypeIdentifierPathPart ConvertToGenericPathPart(GenericIdentifierPathPart identifier)
        {
            var genericParameters = new List<ResolvedTypeIdentifierPath>();
            foreach (var parameter in identifier.GenericParameters)
            {
                // Not sure how we're going to support the ITypeIdentifiers generic parameters
                throw new NotImplementedException();
            }

            return new ResolvedGenericIdentifierPathPart(identifier.Name, genericParameters);
        }

        private static ResolvedTypeIdentifierPathPart ConvertToSimplePathPart(SimpleIdentifierPathPart identifier)
        {
            return new ResolvedSimpleIdentifierPathPart(identifier.Name);
        }
    }
}
