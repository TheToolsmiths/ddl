using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using Ddl.Parser.Resolve.Models.Common.TypeReferences;
using Ddl.Parser.Resolve.Models.FirstPhase.ImportPaths;

using TheToolsmiths.Ddl.Parser.Models.Types.References;
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

        public TypeReference ResolveType(TypeReferencePath typePath)
        {
            if (this.TryResolveFromIndexedTypes(typePath, out var typeReference))
            {
                return typeReference;
            }

            if (this.TryResolveFromImportTypes(typePath, out typeReference))
            {
                return typeReference;
            }

            throw new NotImplementedException();
        }

        private bool TryResolveFromImportTypes(TypeReferencePath typePath, [MaybeNullWhen(false)] out TypeReference typeReference)
        {
            foreach (var importTypeMap in this.ImportLayers)
            {
                if (importTypeMap.TryResolveType(typePath, out typeReference))
                {
                    return true;
                }
            }

            typeReference = default;
            return false;
        }

        private bool TryResolveFromIndexedTypes(TypeReferencePath typePath, [MaybeNullWhen(false)] out TypeReference typeReference)
        {
            return this.IndexedTypes.TryResolveType(typePath, out typeReference);
        }
    }
}
