using System;
using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.Types.References;
using TheToolsmiths.Ddl.Models.Types.References.Resolve;
using TheToolsmiths.Ddl.Models.Types.Resolution;
using TheToolsmiths.Ddl.Models.Types.TypePaths.References;
using TheToolsmiths.Ddl.Parser.TypeIndexer.TypeReferences;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.TypeResolvers
{
    public class ScopeTypeReferenceResolver : IScopeTypeReferenceResolver
    {
        private ScopeTypeReferenceResolver(TypeReferenceIndex typeIndex, TypeReferenceIndexedNamespace namespaceIndex)
        {
            this.TypeIndex = typeIndex;
            this.NamespaceIndex = namespaceIndex;
        }

        public TypeReferenceIndex TypeIndex { get; }

        public TypeReferenceIndexedNamespace NamespaceIndex { get; }

        public TypeReference Resolve(TypeReference typeReference)
        {
            var resolvedEntries = new List<ReferencedTypeResolveState>();

            var resolveState = new ResolveState(resolvedEntries);

            var previousResolvedState = ResolvedTypeKind.Resolved;

            foreach (var referencedType in typeReference.TypeResolve.State.ReferencedTypes)
            {
                if (this.TryResolveStuff(referencedType, resolveState, previousResolvedState, out var resolveResult))
                {
                    previousResolvedState = ResolvedTypeKind.Unresolved;
                }

                resolvedEntries.Add(resolveResult);
            }

            return resolvedEntries[typeReference.TypeResolve.TypeIndex].TypeReference;
        }

        public static ScopeTypeReferenceResolver CreateForNamespace(
            TypeReferenceIndex typeIndex,
            TypeReferenceIndexedNamespace namespaceIndex)
        {
            return new ScopeTypeReferenceResolver(typeIndex, namespaceIndex);
        }

        private bool TryResolveStuff(
            ReferencedTypeResolveState referencedType,
            ResolveState resolveState,
            ResolvedTypeKind previousResolvedState,
            out ReferencedTypeResolveState resolveResult)
        {
            var typeReference = referencedType.TypeReference;

            var typePath = typeReference.TypePath;

            var typeResolution = this.ResolveTypePath(typePath);

            var resolveHandle = typeReference.TypeResolve;

            var resolvedKind = typeResolution switch
            {
                BuiltinType _ => ResolvedTypeKind.Resolved,

                // TODO: Change this to check if the import is valid
                MatchImportResolution _ => ResolvedTypeKind.Unresolved,

                ResolvedType _ => ResolvedTypeKind.Resolved,
                UnresolvedType _ => ResolvedTypeKind.Unresolved,
                _ => throw new ArgumentOutOfRangeException(nameof(typeResolution))
            };

            if (resolvedKind == ResolvedTypeKind.Resolved)
            {
                resolvedKind = previousResolvedState == ResolvedTypeKind.Resolved
                    ? ResolvedTypeKind.Resolved
                    : ResolvedTypeKind.Unresolved;
            }

            var typeResolve = new ResolveStateHandle(resolveHandle.TypeIndex, resolveState, resolvedKind);

            var resolvedTypeReference = new TypeReference(
                typePath,
                typeReference.Storage,
                typeReference.Locality,
                typeReference.Modifiers,
                typeResolve);

            resolveResult = new ReferencedTypeResolveState(resolvedTypeReference, typeResolution);

            return resolvedKind == ResolvedTypeKind.Resolved;
        }

        private TypeResolution ResolveTypePath(TypeReferencePath typePath)
        {
            {
                if (this.TypeIndex.BuiltinTypeReferenceResolver.TryResolveBuiltinType(typePath, out var typeResolution))
                {
                    return typeResolution;
                }
            }

            {
                // TODO: Try resolve imports
            }

            {
                if (this.TryResolveNamespacePath(typePath, out var typeResolution))
                {
                    return typeResolution;
                }
            }

            return TypeResolution.Unresolved;
        }

        private bool TryResolveNamespacePath(TypeReferencePath typePath, out TypeResolution typeResolution)
        {
            if (typePath.IsRooted)
            {
                throw new NotImplementedException();
            }

            return this.TryResolveFromNamespace(typePath.PathParts.Span, this.NamespaceIndex, out typeResolution);
        }

        private bool TryResolveFromNamespace(in ReadOnlySpan<TypeReferencePathPart> pathParts, TypeReferenceIndexedNamespace indexedNamespace, out TypeResolution typeResolution)
        {
            ref readonly var initialPart = ref pathParts[index: 0];

            // Try Resolve Child Item
            {
                if (indexedNamespace.Items.Items.TryGetValue(initialPart.Name, out var indexedPath))
                {
                    if (this.TryResolvePathFromItems(pathParts, indexedPath, out typeResolution))
                    {
                        return true;
                    }
                }
            }

            // Try Resolve Child Namespace
            {
                if (indexedNamespace.ChildNamespaces.TryGetValue(initialPart.Name, out var childNamespace))
                {
                    if (this.TryResolvePathFromChildNamespace(
                        pathParts,
                        childNamespace,
                        out typeResolution))
                    {
                        return true;
                    }
                }
            }

            // Try Resolve Parent Namespaces
            {
                if (this.TryResolveFromParentNamespace(indexedNamespace, pathParts, out typeResolution))
                {
                    return true;
                }
            }

            typeResolution = TypeResolution.Unresolved;
            return false;
        }

        private bool TryResolveFromParentNamespace(
            TypeReferenceIndexedNamespace indexedNamespace,
            in ReadOnlySpan<TypeReferencePathPart> pathParts,
            out TypeResolution typeResolution)
        {
            if (indexedNamespace.HasParent == false)
            {
                typeResolution = TypeResolution.Unresolved;
                return false;
            }

            return this.TryResolveFromNamespace(in pathParts, indexedNamespace.ParentNamespace!, out typeResolution);
        }

        private bool TryResolvePathFromChildNamespace(
            in ReadOnlySpan<TypeReferencePathPart> pathParts,
            TypeReferenceIndexedNamespace indexedNamespace,
            out TypeResolution typeResolution)
        {
            throw new NotImplementedException();
        }

        private bool TryResolvePathFromItems(
            in ReadOnlySpan<TypeReferencePathPart> pathParts,
            TypeReferenceIndexedPath indexedPath,
            out TypeResolution typeResolution)
        {
            if (pathParts.Length == 1)
            {
                ref readonly var itemPart = ref pathParts[index: 0];

                foreach (var itemTypePath in indexedPath.Items)
                {
                    var typeNameIdentifier = itemTypePath.TypedItemName.ItemNameIdentifier;

                    if (typeNameIdentifier.IdentifierKind == itemPart.PartKind)
                    {
                        if (typeNameIdentifier.Name.Equals(itemPart.Name, StringComparison.InvariantCulture))
                        {
                            typeResolution = new ResolvedType(itemTypePath.EntityReference);
                            return true;
                        }
                    }
                }
            }
            else if (pathParts.Length == 2)
            {
                throw new NotImplementedException();
            }
            else
            {
                typeResolution = TypeResolution.Unresolved;
                return false;
            }

            throw new NotImplementedException();
        }
    }
}
