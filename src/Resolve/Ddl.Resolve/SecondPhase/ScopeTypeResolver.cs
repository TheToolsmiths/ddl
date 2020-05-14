using System;
using System.Collections.Generic;
using Ddl.Resolve.Models.FirstPhase.ImportPaths;
using Ddl.Resolve.Models.FirstPhase.Indexing;

namespace TheToolsmiths.Ddl.Resolve.SecondPhase
{
    public class ScopeTypeResolver
    {
        private ScopeTypeResolver(
            IReadOnlyList<IndexedTypeReference> indexedTypes,
            IReadOnlyList<ScopeTypeImportPathLayer> importLayers)
        {
            this.IndexedTypes = indexedTypes;
            this.ImportLayers = importLayers;
        }

        public IReadOnlyList<IndexedTypeReference> IndexedTypes { get; }

        public IReadOnlyList<ScopeTypeImportPathLayer> ImportLayers { get; }

        internal ScopeTypeResolver CreateScopeWithImportPathLayer(IReadOnlyList<FirstPhaseResolvedImportPath> importPaths)
        {
            var layers = new List<ScopeTypeImportPathLayer>
            {
                ScopeTypeImportPathLayer.FromImportPaths(importPaths)
            };

            layers.AddRange(this.ImportLayers);

            return new ScopeTypeResolver(this.IndexedTypes, layers);
        }

        public static ScopeTypeResolver CreateFromIndexedTypes(IReadOnlyList<IndexedTypeReference> indexedTypes)
        {
            return new ScopeTypeResolver(indexedTypes, Array.Empty<ScopeTypeImportPathLayer>());
        }
    }
}
