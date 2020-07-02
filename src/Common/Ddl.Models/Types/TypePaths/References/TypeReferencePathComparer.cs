using System;
using System.Collections.Generic;
using System.Linq;

using TheToolsmiths.Ddl.Models.Types.Names;
using TheToolsmiths.Ddl.Models.Types.TypePaths.Identifiers;
using TheToolsmiths.Ddl.Models.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Models.Types.TypePaths.References
{
    public static class TypeReferencePathComparer
    {
        public static bool CompareFullParts(
            TypeReferencePath lookupPath,
            NamespacePath namespacePrefix,
            TypedItemName typedItemName,
            NamespacePath itemReferenceNamespacePath)
        {
            throw new NotImplementedException();
        }

        public static bool StartsPrefixedWithNamespace(
            TypeReferencePath referencePath,
            NamespacePath namespacePrefix,
            NamespacePath namespacePath)
        {
            if (namespacePrefix.IsRooted == false || namespacePath.IsRooted == false)
            {
                return false;
            }

            var pathParts = referencePath.PathParts;
            var prefixParts = namespacePrefix.Identifiers;
            var namespaceParts = namespacePath.Identifiers;

            if (namespaceParts.Count < prefixParts.Count)
            {
                return false;
            }

            for (int i = 0; i < prefixParts.Count; i++)
            {
                var prefixPart = prefixParts[i];
                var namespacePart = namespaceParts[i];

                if (prefixPart != namespacePart)
                {
                    return false;
                }
            }

            if (pathParts.Count + prefixParts.Count < namespaceParts.Count)
            {
                return false;
            }

            for (int i = 0; i < namespaceParts.Count; i++)
            {
                var pathPart = pathParts[i];
                var namespacePart = namespaceParts[i + prefixParts.Count];

                if (pathPart.PartKind != TypeReferencePathPartKind.Simple)
                {
                    return false;
                }

                if (pathPart.Name != namespacePart)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool StartsWithNamespace(TypeReferencePath referencePath, NamespacePath namespacePath)
        {
            if (referencePath.IsRooted != namespacePath.IsRooted)
            {
                return false;
            }

            var pathParts = referencePath.PathParts;
            var namespaceParts = namespacePath.Identifiers;

            if (referencePath.IsRooted)
            {
                if (pathParts.Count < namespaceParts.Count)
                {
                    return false;
                }

                for (int i = 0; i < namespaceParts.Count; i++)
                {
                    var pathPart = pathParts[i];
                    var namespacePart = namespaceParts[i];

                    if (pathPart.PartKind != TypeReferencePathPartKind.Simple)
                    {
                        return false;
                    }

                    if (pathPart.Name != namespacePart)
                    {
                        return false;
                    }
                }
            }

            throw new NotImplementedException();
        }

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

        private static bool CompareTypePathParts(
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

        private static bool IdentifierFullPartsComparer(TypeReferencePathPart leftPart, TypeIdentifierPathPart rightPart)
        {
            if (ArePartKindsEquivalent(leftPart.PartKind, rightPart.PartKind) == false)
            {
                return false;
            }

            if (leftPart.Name.Equals(rightPart.Name, StringComparison.Ordinal) == false)
            {
                return false;
            }

            if (leftPart is GenericReferencePathPart leftGenericPart &&
                rightPart is GenericIdentifierPathPart rightGenericPart)
            {
                return leftGenericPart.GenericParametersCount == rightGenericPart.GenericParametersCount;
            }

            return false;
        }

        private static bool ArePartKindsEquivalent(TypeReferencePathPartKind leftPartKind, TypeIdentifierPathPartKind rightPartKind)
        {
            return leftPartKind == TypeReferencePathPartKind.Simple &&
                   rightPartKind == TypeIdentifierPathPartKind.Simple ||
                   leftPartKind == TypeReferencePathPartKind.Generic &&
                   rightPartKind == TypeIdentifierPathPartKind.Generic;
        }

        public static bool StartsWithName(TypeReferencePath lookupPath, string identifier)
        {
            if (lookupPath.PathParts.Count == 0)
            {
                return false;
            }

            return lookupPath.PathParts[0].Name.Equals(identifier);
        }

        public static bool CompareFullPartsWithIgnoreNamespaceRoot(TypeReferencePath lookupPath, TypeIdentifierPath typeIdentifier)
        {
            return CompareTypePathParts(lookupPath.PathParts, typeIdentifier.PathParts, IdentifierFullPartsComparer);
        }

        private static bool CompareTypePathParts(
            IReadOnlyList<TypeReferencePathPart> leftParts,
            IReadOnlyList<TypeIdentifierPathPart> rightParts,
            Func<TypeReferencePathPart, TypeIdentifierPathPart, bool> comparer)
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

        public static bool CompareFullParts(TypeReferencePath lookupPath, TypeIdentifierPath typeIdentifier)
        {
            if (lookupPath.IsRooted != typeIdentifier.IsRooted)
            {
                return false;
            }

            return CompareTypePathParts(lookupPath.PathParts, typeIdentifier.PathParts, IdentifierFullPartsComparer);
        }
    }
}
