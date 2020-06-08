using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

using Ddl.Common;
using Ddl.Parser.Resolve.Models.FirstPhase.ImportPaths;

using TheToolsmiths.Ddl.Parser.Models.References.TypeReferences;
using TheToolsmiths.Ddl.Parser.Models.Types.References;
using TheToolsmiths.Ddl.Parser.Models.Types.Resolved;
using TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.Namespaces;
using TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.References;

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

        internal static ScopeTypeResolver CreateFromIndexedTypes(
            NamespacePath scopeNamespace,
            IReadOnlyList<EntityTypeReference> indexedTypes)
        {
            return new ScopeTypeResolver(IndexedTypePathMap.FromIndexedTypes(scopeNamespace, indexedTypes));
        }

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

        public Result<TypeReference> ResolveTypeReference(TypeReference typeReference)
        {
            var builtReferences = typeReference.ResolveState.BuiltReferences.ToArray();

            for (int i = 0; i < builtReferences.Length; i++)
            {
                TypeReference builtReference = builtReferences[i];

                TypeResolution typeResolution = this.ResolveType(builtReference.TypePath);

                var updatedReference = builtReference.WithTypeResolution(typeResolution);

                builtReferences[i] = updatedReference;
            }

            var resolvedKind = ResolvedTypeKindHelper.GetResolvedKind(builtReferences);

            var resolvedReference = builtReferences.First().WithResolvedKind(resolvedKind);

            return Result.FromValue(resolvedReference);
        }

        private TypeResolution ResolveType(TypeReferencePath typePath)
        {
            if (this.TryResolveFromIndexedTypes(typePath, out var typeResolution))
            {
                return typeResolution;
            }

            if (this.TryResolveFromImportTypes(typePath, out typeResolution))
            {
                return typeResolution;
            }

            return TypeResolution.Unresolved;
        }

        private bool TryResolveFromImportTypes(TypeReferencePath typePath, [MaybeNullWhen(false)] out TypeResolution typeResolution)
        {
            foreach (var importTypeMap in this.ImportLayers)
            {
                if (importTypeMap.TryResolveType(typePath, out typeResolution))
                {
                    return true;
                }
            }

            typeResolution = default;
            return false;
        }

        private bool TryResolveFromIndexedTypes(TypeReferencePath typePath, [MaybeNullWhen(false)] out TypeResolution typeResolution)
        {
            return this.IndexedTypes.TryResolveType(typePath, out typeResolution);
        }
    }
}
