using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TheToolsmiths.Ddl.Parser.Models.References.TypeReferences;
using TheToolsmiths.Ddl.Parser.Models.Types.Resolution;
using TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.Identifiers;
using TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.Namespaces;
using TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.References;

namespace TheToolsmiths.Ddl.TypeResolution
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
            [MaybeNullWhen(returnValue: false)] out Parser.Models.Types.Resolution.TypeResolution typeResolution)
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

                throw new NotImplementedException();

                //var rootedLookupPath =
                //    TypeReferencePathBuilder.PrependNamespace(lookupPath, this.scopeNamespace);

                //if (TypeReferencePathComparer.CompareFullParts(rootedLookupPath, typeIdentifier))
                //{
                //    throw new NotImplementedException();
                //}

                //return false;
            }

            if (TypeReferencePathComparer.CompareFullParts(lookupPath, typeIdentifier))
            {
                throw new NotImplementedException();
            }

            return false;
        }
    }
}
