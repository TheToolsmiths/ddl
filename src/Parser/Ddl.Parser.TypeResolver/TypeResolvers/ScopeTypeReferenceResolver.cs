using System;
using System.Collections.Generic;
using System.Linq;

using TheToolsmiths.Ddl.Models.ImportPaths;
using TheToolsmiths.Ddl.Models.Packages.Index;
using TheToolsmiths.Ddl.Models.Paths;
using TheToolsmiths.Ddl.Models.Types.Index;
using TheToolsmiths.Ddl.Models.Types.Names;
using TheToolsmiths.Ddl.Models.Types.References;
using TheToolsmiths.Ddl.Models.Types.References.Resolve;
using TheToolsmiths.Ddl.Models.Types.Resolution;
using TheToolsmiths.Ddl.Models.Types.TypePaths.References;
using TheToolsmiths.Ddl.Parser.TypeIndexer.TypeResolvers.BuiltinTypes;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.TypeResolvers
{
    public class ScopeTypeReferenceResolver : IScopeTypeReferenceResolver
    {
        private ScopeTypeReferenceResolver(
            PackageTypeIndex packageTypeIndex,
            TypeIndexedNamespace namespaceIndex,
            ImportPathReferenceResolver importPathResolver,
            BuiltinTypeReferenceResolver builtinTypeReferenceResolver,
            IReadOnlyDictionary<string, GenericTypeNameParameter> genericParameters)
        {
            this.BuiltinTypeReferenceResolver = builtinTypeReferenceResolver;
            this.PackageTypeIndex = packageTypeIndex;
            this.NamespaceIndex = namespaceIndex;
            this.GenericParameters = genericParameters;
            this.ImportPathResolver = importPathResolver;
        }

        public IReadOnlyDictionary<string, GenericTypeNameParameter> GenericParameters { get; }

        public BuiltinTypeReferenceResolver BuiltinTypeReferenceResolver { get; }

        public PackageTypeIndex PackageTypeIndex { get; }

        public TypeIndexedNamespace NamespaceIndex { get; }

        public ImportPathReferenceResolver ImportPathResolver { get; }

        public TypeReference Resolve(TypeReference typeReference)
        {
            var resolvedEntries = new List<ReferencedTypeResolveState>();

            var resolveState = new ResolveState(resolvedEntries);

            var previousResolvedState = ResolvedTypeKind.Resolved;

            foreach (var referencedType in typeReference.TypeResolve.State.ReferencedTypes)
            {
                if (this.TryResolveReferencedType(
                    referencedType,
                    resolveState,
                    previousResolvedState,
                    out var resolveResult))
                {
                    previousResolvedState = ResolvedTypeKind.Unresolved;
                }

                resolvedEntries.Add(resolveResult);
            }

            return resolvedEntries[typeReference.TypeResolve.TypeIndex].TypeReference;
        }

        public TypeResolution ResolveImportPath(ImportPath importPath)
        {
            // Resolve BuiltIn Types
            {
                if (this.BuiltinTypeReferenceResolver.TryResolveBuiltinType(
                    importPath,
                    out var typeResolution))
                {
                    return typeResolution;
                }
            }

            // Resolve Imports
            {
                if (this.TryResolveImportedPath(importPath, out var typeResolution))
                {
                    return typeResolution;
                }
            }

            // Resolve Namespace scoped Types
            {
                if (this.TryResolveNamespacePath(importPath, out var typeResolution))
                {
                    return typeResolution;
                }
            }

            return TypeResolution.Unresolved;
        }

        public ScopeTypeReferenceResolver AddGenericParameters(
            IReadOnlyList<GenericTypeNameParameter> genericParameters)
        {
            var concatParams = this.GenericParameters.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            foreach (var genericParameter in genericParameters)
            {
                concatParams.Add(genericParameter.Text, genericParameter);
            }

            return new ScopeTypeReferenceResolver(
                this.PackageTypeIndex,
                this.NamespaceIndex,
                this.ImportPathResolver,
                this.BuiltinTypeReferenceResolver,
                concatParams);
        }

        public ScopeTypeReferenceResolver AddImports(ImportStatementCollection imports)
        {
            var updatedImportPathResolver = this.ImportPathResolver.AddImports(this, imports);

            return new ScopeTypeReferenceResolver(
                this.PackageTypeIndex,
                this.NamespaceIndex,
                updatedImportPathResolver,
                this.BuiltinTypeReferenceResolver,
                this.GenericParameters);
        }

        public static ScopeTypeReferenceResolver CreateForNamespace(
            PackageTypeIndex packageTypeIndex,
            TypeIndexedNamespace namespaceIndex,
            BuiltinTypeReferenceResolver builtinTypeReferenceResolver)
        {
            var importPathResolver = new ImportPathReferenceResolver();

            return new ScopeTypeReferenceResolver(
                packageTypeIndex,
                namespaceIndex,
                importPathResolver,
                builtinTypeReferenceResolver,
                new Dictionary<string, GenericTypeNameParameter>());
        }

        private bool TryResolveReferencedType(
            ReferencedTypeResolveState referencedType,
            ResolveState resolveState,
            ResolvedTypeKind previousResolvedState,
            out ReferencedTypeResolveState resolveResult)
        {
            var typeReference = referencedType.TypeReference;

            var typePath = typeReference.TypePath;

            var typeResolution = this.ResolveTypePath(typePath);

            var resolveHandle = typeReference.TypeResolve;

            var resolvedKind = GetTypeResolvedKind(typeResolution);

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

            ResolvedTypeKind GetTypeResolvedKind(TypeResolution resolution)
            {
                return resolution switch
                {
                    BuiltinType _ => ResolvedTypeKind.Resolved,

                    MatchImportResolution import => GetTypeResolvedKind(import.ImportPathTypeResolution),

                    MatchGenericParameterResolution _ => ResolvedTypeKind.Unresolved,

                    ResolvedType _ => ResolvedTypeKind.Resolved,
                    UnresolvedType _ => ResolvedTypeKind.Unresolved,
                    _ => throw new ArgumentOutOfRangeException(nameof(typeResolution))
                };
            }
        }

        private TypeResolution ResolveTypePath(TypeReferencePath typePath)
        {
            // Resolve Generic Parameters
            {
                if (this.TryResolveGenericParameter(typePath, out var typeResolution))
                {
                    return typeResolution;
                }
            }

            // Resolve BuiltIn Types
            {
                if (this.BuiltinTypeReferenceResolver.TryResolveBuiltinType(typePath, out var typeResolution))
                {
                    return typeResolution;
                }
            }

            // Resolve Imports
            {
                if (this.TryResolveImportedPath(typePath, out var typeResolution))
                {
                    return typeResolution;
                }
            }

            // Resolve Namespace scoped Types
            {
                if (this.TryResolveNamespacePath(typePath, out var typeResolution))
                {
                    return typeResolution;
                }
            }

            return TypeResolution.Unresolved;
        }

        private bool TryResolveGenericParameter(TypeReferencePath typePath, out TypeResolution typeResolution)
        {
            if (typePath.IsRooted)
            {
                typeResolution = TypeResolution.Unresolved;
                return false;
            }

            if (typePath.PathParts.Length != 1)
            {
                typeResolution = TypeResolution.Unresolved;
                return false;
            }

            ref readonly var pathPart = ref typePath.PathParts.AsSpan()[index: 0];

            if (pathPart.PartKind != PathPartKind.Simple)
            {
                typeResolution = TypeResolution.Unresolved;
                return false;
            }

            string partName = pathPart.Name;

            if (this.GenericParameters.TryGetValue(partName, out var genericTypeNameParameter) == false)
            {
                typeResolution = TypeResolution.Unresolved;
                return false;
            }

            typeResolution = new MatchGenericParameterResolution(genericTypeNameParameter.Text);
            return true;
        }

        private bool TryResolveImportedPath<T>(IQualifiedPath<T> typePath, out TypeResolution typeResolution)
            where T : IPathPart
        {
            var pathParts = typePath.PathParts.AsSpan();

            if (typePath.IsRooted || pathParts.Length == 0)
            {
                typeResolution = TypeResolution.Unresolved;
                return false;
            }

            ref readonly var itemPart = ref pathParts[index: 0];

            if (itemPart.PartKind != PathPartKind.Simple)
            {
                typeResolution = TypeResolution.Unresolved;
                return false;
            }

            if (this.ImportPathResolver.TryGetImportPathResolve(itemPart.Name, out var importResolution) == false)
            {
                typeResolution = TypeResolution.Unresolved;
                return false;
            }

            // If the path only has a part
            if (pathParts.Length == 1)
            {
                // Then we're done looking
                typeResolution = new MatchImportResolution(
                    importResolution.ImportPathReference,
                    importResolution.TypeResolution);
                return true;
            }

            // If import resolves to a namespace, finish resolving it
            if (importResolution.TypeResolution is ResolvedNamespace resolvedNamespace)
            {
                throw new NotImplementedException();
            }
            // If import resolves to another import, recursively check the resolves of the imports
            else if (importResolution.TypeResolution is MatchImportResolution matchImportResolution)
            {
                throw new NotImplementedException();
            }

            typeResolution = TypeResolution.Unresolved;
            return false;
        }

        private bool TryResolveNamespacePath<T>(IQualifiedPath<T> typePath, out TypeResolution typeResolution)
            where T : IPathPart
        {
            var namespaceIndex = this.NamespaceIndex;

            if (typePath.IsRooted)
            {
                namespaceIndex = this.NamespaceIndex.RootNamespace;
            }

            return this.TryResolveFromNamespace(typePath.PathParts.AsSpan(), namespaceIndex, out typeResolution);
        }

        private bool TryResolveFromNamespace<T>(
            in ReadOnlySpan<T> pathParts,
            TypeIndexedNamespace indexedNamespace,
            out TypeResolution typeResolution)
            where T : IPathPart
        {
            // Try Resolve Child Entries
            {
                if (this.TryResolveFromChildEntries(pathParts, indexedNamespace, out typeResolution))
                {
                    return true;
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

        private bool TryResolveFromChildEntries<T>(
            in ReadOnlySpan<T> pathParts,
            TypeIndexedNamespace indexedNamespace,
            out TypeResolution typeResolution)
            where T : IPathPart
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
            if (pathParts.Length > 1)
            {
                if (indexedNamespace.ChildNamespaces.TryGetValue(initialPart.Name, out var childNamespace))
                {
                    if (this.TryResolvePathFromChildNamespace(pathParts[1..], childNamespace, out typeResolution))
                    {
                        return true;
                    }
                }
            }

            if (pathParts.Length == 1)
            {
                if (indexedNamespace.ChildNamespaces.TryGetValue(initialPart.Name, out var childNamespace))
                {
                    typeResolution = new ResolvedNamespace(childNamespace.NamespacePath);
                    return true;
                }
            }

            typeResolution = TypeResolution.Unresolved;
            return false;
        }

        private bool TryResolveFromParentNamespace<T>(
            TypeIndexedNamespace indexedNamespace,
            in ReadOnlySpan<T> pathParts,
            out TypeResolution typeResolution)
            where T : IPathPart
        {
            if (indexedNamespace.HasParent == false)
            {
                typeResolution = TypeResolution.Unresolved;
                return false;
            }

            return this.TryResolveFromNamespace(in pathParts, indexedNamespace.ParentNamespace!, out typeResolution);
        }

        private bool TryResolvePathFromChildNamespace<T>(
            in ReadOnlySpan<T> pathParts,
            TypeIndexedNamespace indexedNamespace,
            out TypeResolution typeResolution)
            where T : IPathPart
        {
            if (this.TryResolveFromChildEntries(pathParts, indexedNamespace, out typeResolution))
            {
                return true;
            }

            typeResolution = TypeResolution.Unresolved;
            return false;
        }

        private bool TryResolvePathFromItems<T>(
            in ReadOnlySpan<T> pathParts,
            TypeIndexedPath indexedPath,
            out TypeResolution typeResolution)
            where T : IPathPart
        {
            if (pathParts.Length == 1)
            {
                ref readonly var itemPart = ref pathParts[index: 0];

                foreach (var itemTypePath in indexedPath.Items)
                {
                    var typeNameIdentifier = itemTypePath.TypedItemName.ItemName;

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
