using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TheToolsmiths.Ddl.Parser.Models.References.TypeReferences;
using TheToolsmiths.Ddl.Parser.Models.Types.Resolved;
using TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.Identifiers;
using TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.Namespaces;
using TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.References;
using TheToolsmiths.Ddl.Resolve.Common.TypeHelpers;

namespace TheToolsmiths.Ddl.Resolve.SecondPhase
{
    public class IndexedTypePathMap
    {
        private readonly IReadOnlyList<EntityTypeReference> entityReferences;
        private readonly NamespacePath scopeNamespace;

        private IndexedTypePathMap(
            NamespacePath scopeNamespace,
            IReadOnlyList<EntityTypeReference> entityReferences)
        {
            this.scopeNamespace = scopeNamespace;
            this.entityReferences = entityReferences;
        }

        public static IndexedTypePathMap FromIndexedTypes(
            NamespacePath scopeNamespace,
            IReadOnlyList<EntityTypeReference> indexedTypes)
        {
            return new IndexedTypePathMap(scopeNamespace, indexedTypes);
        }

        public bool TryResolveType(
            TypeReferencePath lookupPath,
            [MaybeNullWhen(returnValue: false)] out TypeResolution typeResolution)
        {
            foreach (var entityReference in this.entityReferences)
            {
                if (this.TryMatch(lookupPath, entityReference.TypeIdentifier))
                {
                    typeResolution = new ResolvedType(entityReference.EntityReference);
                    return true;
                }
            }

            typeResolution = default;
            return false;
        }

        // TODO: Delete
        private bool TryMatchItemReference(TypeReferencePath lookupPath, ItemTypePathReference itemReference)
        {
            if (itemReference.NamespacePath.IsRooted == false)
            {
                // And reference isn't, throw an error since item references namespaces should be rooted
                throw new NotImplementedException();
            }

            // If the lookup path is rooted
            if (lookupPath.IsRooted)
            {
                // Compare it directly with the item reference namespace
                if (TypeReferencePathComparer.StartsWithNamespace(lookupPath, itemReference.NamespacePath))
                {
                    throw new NotImplementedException();
                }
            }
            // If the lookup path is not rooted
            else
            {
                // Compare the current scope namespace with the item reference namespace
                if (NamespacePathComparer.StartsWithRootedNamespace(itemReference.NamespacePath, this.scopeNamespace))
                {
                    return TypeReferencePathComparer.CompareFullParts(
                        lookupPath,
                        this.scopeNamespace,
                        itemReference.ItemTypeName,
                        itemReference.NamespacePath);
                }

                return false;
            }

            throw new NotImplementedException();

            //// If lookup path is rooted
            //if (lookupPath.IsRooted)
            //{

            //    // If both are rooted, compare the type path parts
            //    throw new NotImplementedException();
            //}

            //// If type reference is rooted,
            //// root the lookupPath with the scope rooted namespace and compare both
            //if (itemReference.NamespacePath.IsRooted)
            //{
            //    if (TypeReferencePathComparer.CompareFullPartsWithIgnoreNamespaceRoot(lookupPath, typeReference))
            //    {
            //        throw new NotImplementedException();
            //    }

            //    var foo = ResolveTypeReferencePathBuilder.PrependNamespace(lookupPath, this.scopeNamespace);

            //    if (TypeReferencePathComparer.CompareFullParts(foo, typeReference))
            //    {
            //        throw new NotImplementedException();
            //    }

            //    return false;
            //}

            //if (TypeReferencePathComparer.CompareFullParts(lookupPath, typeReference))
            //{
            //    throw new NotImplementedException();
            //}

            //return false;
        }

        private bool TryMatch(TypeReferencePath lookupPath, TypeIdentifierPath typeIdentifier)
        {
            // If lookup path is rooted
            if (lookupPath.IsRooted)
            {
                if (typeIdentifier.IsRooted == false)
                {
                    // And reference isn't, they're not the same type.
                    return false;
                }

                // If both are rooted, compare the type path parts
                throw new NotImplementedException();
            }

            // If type reference is rooted,
            // root the lookupPath with the scope rooted namespace and compare both
            if (typeIdentifier.IsRooted)
            {
                if (TypeReferencePathComparer.CompareFullPartsWithIgnoreNamespaceRoot(lookupPath, typeIdentifier))
                {
                    return true;
                }

                var rootedLookupPath =
                    ResolveTypeReferencePathBuilder.PrependNamespace(lookupPath, this.scopeNamespace);

                if (TypeReferencePathComparer.CompareFullParts(rootedLookupPath, typeIdentifier))
                {
                    throw new NotImplementedException();
                }

                return false;
            }

            if (TypeReferencePathComparer.CompareFullParts(lookupPath, typeIdentifier))
            {
                throw new NotImplementedException();
            }

            return false;
        }
    }
}
