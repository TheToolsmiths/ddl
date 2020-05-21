using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Ddl.Parser.Resolve.Models.Common.TypeReferences;
using Ddl.Parser.Resolve.Models.Common.TypeResolve;
using Ddl.Parser.Resolve.Models.FirstPhase.ImportPaths;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Identifiers;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Namespaces;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Paths;

namespace TheToolsmiths.Ddl.Resolve.SecondPhase
{
    public class ScopeTypeResolver
    {
        private ScopeTypeResolver(IndexedTypePathMap indexedTypes)
            : this(indexedTypes, Array.Empty<IndexedImportPathMap>())
        {
        }

        private ScopeTypeResolver(IndexedTypePathMap indexedTypes, IReadOnlyList<IndexedImportPathMap> importLayers)
        {
            this.IndexedTypes = indexedTypes;
            this.ImportLayers = importLayers;
        }

        public IndexedTypePathMap IndexedTypes { get; }

        public IReadOnlyList<IndexedImportPathMap> ImportLayers { get; }

        internal ScopeTypeResolver CreateScopeWithImportPathLayer(
            NamespacePath scopeNamespace,
            IReadOnlyList<FirstPhaseResolvedImportPath> importPaths)
        {
            var layers = new List<IndexedImportPathMap>
            {
                IndexedImportPathMap.FromImportPaths(scopeNamespace, importPaths)
            };

            layers.AddRange(this.ImportLayers);

            return new ScopeTypeResolver(this.IndexedTypes, layers);
        }

        public static ScopeTypeResolver CreateFromIndexedTypes(
            NamespacePath scopeNamespace,
            IReadOnlyList<TypePathEntityReference> indexedTypes)
        {
            return new ScopeTypeResolver(IndexedTypePathMap.FromIndexedTypes(scopeNamespace, indexedTypes));
        }

        public bool TryResolveType(TypeIdentifierPath typePath, [MaybeNullWhen(false)] out ResolvedType resolvedType)
        {
            if (this.IndexedTypes.TryResolveType(typePath, out resolvedType))
            {
                return true;
            }

            foreach (var importTypeMap in this.ImportLayers)
            {
                if (importTypeMap.TryResolveType(typePath, out resolvedType))
                {
                    return true;
                }
            }

            resolvedType = default;
            return false;
        }

        public ResolvedType ResolveType(ITypeIdentifier typeIdentifier)
        {
            var qualifiedTypeIdentifier = TypeIdentifierHelpers.GetQualifiedType(typeIdentifier);

            if (this.TryResolveType(qualifiedTypeIdentifier.TypePath, out var resolvedType))
            {
                return resolvedType;
            }

            return new UnresolvedType(qualifiedTypeIdentifier.TypePath);
        }

        public bool TryResolveType(TypeReferencePath typePath, [MaybeNullWhen(false)] out ResolvedType resolvedType)
        {
            if (this.IndexedTypes.TryResolveType(typePath, out resolvedType))
            {
                return true;
            }

            foreach (var importTypeMap in this.ImportLayers)
            {
                if (importTypeMap.TryResolveType(typePath, out resolvedType))
                {
                    return true;
                }
            }

            resolvedType = default;
            return false;
        }
    }
}
