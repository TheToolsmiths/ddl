using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

using TheToolsmiths.Ddl.Models.Build.ImportPaths;
using TheToolsmiths.Ddl.Models.Build.Indexing;
using TheToolsmiths.Ddl.Models.Build.Types.Paths;
using TheToolsmiths.Ddl.Models.Build.Types.Usage;
using TheToolsmiths.Ddl.Models.Compiled.Types.Resolution;
using TheToolsmiths.Ddl.Models.Compiled.Types.Usage;
using TheToolsmiths.Ddl.Models.Paths;
using TheToolsmiths.Ddl.Models.Types.Names;
using TheToolsmiths.Ddl.Parser.Compiler.Helpers;
using TheToolsmiths.Ddl.Parser.Compiler.TypeResolvers.BuiltinTypes;

namespace TheToolsmiths.Ddl.Parser.Compiler.TypeResolvers
{
    public class ScopeTypeUseResolver : IScopeTypeUseResolver
    {
        private ScopeTypeUseResolver(
            ContentUnitsTypeIndex packageTypeIndex,
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

        public ContentUnitsTypeIndex PackageTypeIndex { get; }

        public TypeIndexedNamespace NamespaceIndex { get; }

        public ImportPathReferenceResolver ImportPathResolver { get; }

        public ResolvedTypeUse Resolve(TypeUse typeUse)
        {
            var resolution = this.ResolveType(typeUse.TypePath);

            var storage = typeUse.Storage;
            var locality = typeUse.Locality;
            var modifiers = typeUse.Modifiers;

            return new ResolvedTypeUse(resolution, storage, locality, modifiers);
        }

        public TypeResolution ResolveImportPath(ImportPath importPath)
        {
            // Resolve BuiltIn Types
            {
                if (this.BuiltinTypeReferenceResolver.TryResolveBuiltinType(importPath, out var typeResolution))
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

        public ScopeTypeUseResolver AddGenericParameters(
            IReadOnlyList<GenericTypeNameParameter> genericParameters)
        {
            var concatParams = this.GenericParameters.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            foreach (var genericParameter in genericParameters)
            {
                concatParams.Add(genericParameter.Text, genericParameter);
            }

            return new ScopeTypeUseResolver(
                this.PackageTypeIndex,
                this.NamespaceIndex,
                this.ImportPathResolver,
                this.BuiltinTypeReferenceResolver,
                concatParams);
        }

        public ScopeTypeUseResolver AddImports(ImportStatementCollection imports)
        {
            var updatedImportPathResolver = this.ImportPathResolver.AddImports(this, imports);

            return new ScopeTypeUseResolver(
                this.PackageTypeIndex,
                this.NamespaceIndex,
                updatedImportPathResolver,
                this.BuiltinTypeReferenceResolver,
                this.GenericParameters);
        }

        public static ScopeTypeUseResolver CreateForNamespace(
            ContentUnitsTypeIndex packageTypeIndex,
            TypeIndexedNamespace namespaceIndex,
            BuiltinTypeReferenceResolver builtinTypeReferenceResolver)
        {
            var importPathResolver = new ImportPathReferenceResolver();

            return new ScopeTypeUseResolver(
                packageTypeIndex,
                namespaceIndex,
                importPathResolver,
                builtinTypeReferenceResolver,
                new Dictionary<string, GenericTypeNameParameter>());
        }

        //private bool TryResolveReferencedType(
        //    ReferencedTypeResolveState referencedType,
        //    ResolveState resolveState,
        //    ResolvedTypeKind previousResolvedState,
        //    out ReferencedTypeResolveState resolveResult)
        //{
        //    var typeReference = referencedType.TypeReference;

        //    var typePath = typeReference.ResolvedTypePath;

        //    var typeResolution = this.ResolveTypePath(typePath);

        //    var resolveHandle = typeReference.TypeResolve;

        //    var resolvedKind = GetTypeResolvedKind(typeResolution);

        //    if (resolvedKind == ResolvedTypeKind.Resolved)
        //    {
        //        resolvedKind = previousResolvedState == ResolvedTypeKind.Resolved
        //            ? ResolvedTypeKind.Resolved
        //            : ResolvedTypeKind.Unresolved;
        //    }

        //    var typeResolve = new ResolveStateHandle(resolveHandle.TypeIndex, resolveState, resolvedKind);

        //    var resolvedTypeReference = new TypeReference(
        //        typePath,
        //        typeReference.Storage,
        //        typeReference.Locality,
        //        typeReference.Modifiers,
        //        typeResolve);

        //    resolveResult = new ReferencedTypeResolveState(resolvedTypeReference, typeResolution);

        //    return resolvedKind == ResolvedTypeKind.Resolved;

        //    ResolvedTypeKind GetTypeResolvedKind(TypeResolution resolution)
        //    {
        //        return resolution switch
        //        {
        //            BuiltinTypeResolution _ => ResolvedTypeKind.Resolved,

        //            MatchImportResolution import => GetTypeResolvedKind(import.ImportPathTypeResolution),

        //            GenericParameterResolution _ => ResolvedTypeKind.Unresolved,

        //            ResolvedType _ => ResolvedTypeKind.Resolved,
        //            UnresolvedType _ => ResolvedTypeKind.Unresolved,
        //            _ => throw new ArgumentOutOfRangeException(nameof(typeResolution))
        //        };
        //    }
        //}

        private TypeResolution ResolveType(TypePath typePath)
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

        private bool TryResolveGenericParameter(TypePath typePath, out TypeResolution typeResolution)
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

            ref readonly var pathPart = ref typePath.PathParts.AsSpan()[0];

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

            typeResolution = new GenericParameterResolution(genericTypeNameParameter.Text);
            return true;
        }

        private bool TryResolveImportedPath<T>(IPath<T> typePath, out TypeResolution typeResolution)
            where T : IPathPart
        {
            var pathParts = typePath.PathParts.AsSpan();

            if (typePath.IsRooted || pathParts.Length == 0)
            {
                typeResolution = TypeResolution.Unresolved;
                return false;
            }

            ref readonly var itemPart = ref pathParts[0];

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
                    EntityReferenceHelper.ToItemReference(importResolution.ImportPathReference),
                    importResolution.TypeResolution);
                return true;
            }

            // If import resolves to a namespace, finish resolving it
            if (importResolution.TypeResolution is ResolvedNamespace resolvedNamespace)
            {
                throw new NotImplementedException();
            }

            // If import resolves to another import, recursively check the resolves of the imports
            if (importResolution.TypeResolution is MatchImportResolution matchImportResolution)
            {
                typeResolution = this.ResolveMatchImportResolution(matchImportResolution, typePath.PathParts);
                return true;
            }

            typeResolution = TypeResolution.Unresolved;
            return false;
        }

        private TypeResolution ResolveMatchImportResolution<T>(
            MatchImportResolution matchImportResolution,
            ImmutableArray<T> typePathParts)
            where T : IPathPart
        {
            switch (matchImportResolution.ImportPathTypeResolution)
            {
                case ResolvedBuiltinType builtinType:
                    break;
                case GenericParameterResolution matchGenericParameterResolution:
                    break;
                case MatchImportResolution childImportResolution:
                    {
                        var childResolution = this.ResolveMatchImportResolution(childImportResolution, typePathParts);
                        return new MatchImportResolution(matchImportResolution.ImportPathReference, childResolution);
                    }
                case ResolvedNamespace resolvedNamespace:
                    break;
                case ResolvedType resolvedType:
                    break;
                case UnresolvedType unresolvedType:
                    return matchImportResolution;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            throw new NotImplementedException();
        }

        private bool TryResolveNamespacePath<T>(IPath<T> typePath, out TypeResolution typeResolution)
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
            ref readonly var initialPart = ref pathParts[0];

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
                    typeResolution = new ResolvedNamespace(NamespaceHelper.CreateQualifiedNamespace(childNamespace.NamespacePath));
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
                ref readonly var itemPart = ref pathParts[0];

                foreach (var itemTypePath in indexedPath.Items)
                {
                    var typeNameIdentifier = itemTypePath.TypeName.ItemName;

                    if (typeNameIdentifier.IdentifierKind == itemPart.PartKind)
                    {
                        if (typeNameIdentifier.Name.Equals(itemPart.Name, StringComparison.InvariantCulture))
                        {
                            typeResolution = new ResolvedType(EntityReferenceHelper.CreateEntityReference(itemTypePath.EntityReference));
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
