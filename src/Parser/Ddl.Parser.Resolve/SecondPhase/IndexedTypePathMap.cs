using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Ddl.Parser.Resolve.Models.Common.TypeReferences;
using Ddl.Parser.Resolve.Models.Common.TypeResolve;
using TheToolsmiths.Ddl.Parser.Models.Types.Namespaces;
using TheToolsmiths.Ddl.Parser.Models.Types.Paths;

namespace TheToolsmiths.Ddl.Resolve.SecondPhase
{
    public class IndexedTypePathMap
    {
        private readonly IReadOnlyList<TypePathEntityReference> indexedTypes;
        private readonly NamespacePath scopeNamespace;

        private IndexedTypePathMap(NamespacePath scopeNamespace, IReadOnlyList<TypePathEntityReference> indexedTypes)
        {
            this.scopeNamespace = scopeNamespace;
            this.indexedTypes = indexedTypes;
        }

        public static IndexedTypePathMap FromIndexedTypes(
            NamespacePath scopeNamespace,
            IReadOnlyList<TypePathEntityReference> indexedTypes)
        {
            return new IndexedTypePathMap(scopeNamespace, indexedTypes);
        }

        public bool TryResolveType(TypeIdentifierPath lookupPath, [MaybeNullWhen(false)] out ResolvedType resolvedType)
        {
            var referenceLookupPath = TypeReferencePath.CreateFromIdentifierPath(lookupPath);

            return this.TryResolveType(referenceLookupPath, out resolvedType);
        }

        public bool TryResolveType(TypeReferencePath lookupPath, [MaybeNullWhen(false)] out ResolvedType resolvedType)
        {
            foreach (var entityReference in this.indexedTypes)
            {
                if (this.TryMatch(lookupPath, entityReference.TypeNameReference))
                {
                    throw new NotImplementedException();
                }
            }

            resolvedType = default;
            return false;
        }

        private bool TryMatch(TypeReferencePath lookupPath, TypeReferencePath typeReference)
        {
            // If lookup path is rooted
            if (lookupPath.IsRooted)
            {
                if (typeReference.IsRooted == false)
                {
                    // And reference isn't, they're not the same type.
                    return false;
                }

                // If both are rooted, compare the type path parts
                throw new NotImplementedException();
            }

            // If type reference is rooted,
            // root the lookupPath with the scope rooted namespace and compare both
            if (typeReference.IsRooted)
            {
                if (TypeReferencePathComparer.CompareFullPartsWithIgnoreNamespaceRoot(lookupPath, typeReference))
                {
                    throw new NotImplementedException();
                }

                var foo = TypeReferencePathBuilder.PrependNamespace(lookupPath, this.scopeNamespace);


                if (TypeReferencePathComparer.CompareFullParts(foo, typeReference))
                {
                    throw new NotImplementedException();
                }

                return false;
            }

            if (TypeReferencePathComparer.CompareFullParts(lookupPath, typeReference))
            {
                throw new NotImplementedException();
            }

            return false;
        }
    }
}
