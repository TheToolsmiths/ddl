using System;
using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Parser.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Models.TypePaths.References
{
    public static class TypeReferencePathComparer
    {
        public static bool CompareFullParts(TypeReferencePath lookupPath, TypeReferencePath typeReference)
        {
            if (lookupPath.IsRooted != typeReference.IsRooted)
            {
                return false;
            }

            return CompareTypePathParts(lookupPath.PathParts, typeReference.PathParts, FullPartsComparer);
        }

        public static bool CompareFullPartsWithIgnoreNamespaceRoot(
            TypeReferencePath lookupPath,
            TypeReferencePath typeReference)
        {
            return CompareTypePathParts(lookupPath.PathParts, typeReference.PathParts, FullPartsComparer);
        }

        public static bool CompareTypePathParts(
            IReadOnlyList<TypeReferencePathPart> leftParts,
            IReadOnlyList<TypeReferencePathPart> rightParts,
            Func<TypeReferencePathPart, TypeReferencePathPart, bool> comparer)
        {
            if (leftParts.Count != rightParts.Count)
            {
                return false;
            }

            foreach (var (leftPart, rightPart) in leftParts.Zip(
                rightParts,
                (leftPart, rightPart) => (leftPart, rightPart)))
            {
                if (comparer(leftPart, rightPart) == false)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool FullPartsComparer(TypeReferencePathPart leftPart, TypeReferencePathPart rightPart)
        {
            if (leftPart.PartKind != rightPart.PartKind)
            {
                return false;
            }

            if (leftPart.Name.Equals(rightPart.Name) == false)
            {
                return false;
            }

            if (leftPart is GenericReferencePathPart leftGenericPart &&
                rightPart is GenericReferencePathPart rightGenericPart)
            {
                return leftGenericPart.GenericParametersCount == rightGenericPart.GenericParametersCount;
            }

            return false;
        }

        public static bool StartsWithName(TypeReferencePath lookupPath, Identifier identifier)
        {
            if (lookupPath.PathParts.Count == 0)
            {
                return false;
            }

            return lookupPath.PathParts[0].Name.Equals(identifier);
        }
    }
}
