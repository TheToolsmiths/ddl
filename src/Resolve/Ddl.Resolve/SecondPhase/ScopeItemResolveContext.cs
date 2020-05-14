using System.Collections.Generic;
using Ddl.Resolve.Models.FirstPhase.ImportPaths;
using Ddl.Resolve.Models.FirstPhase.Indexing;

namespace TheToolsmiths.Ddl.Resolve.SecondPhase
{
    public class ScopeItemResolveContext
    {
        private ScopeItemResolveContext(ScopeTypeResolver typeResolver)
        {
            this.TypeResolver = typeResolver;
        }

        public ScopeTypeResolver TypeResolver { get; }

        public static ScopeItemResolveContext CreateForRoot(IReadOnlyList<IndexedTypeReference> indexedTypes)
        {
            var typeResolver = ScopeTypeResolver.CreateFromIndexedTypes(indexedTypes);

            return new ScopeItemResolveContext(typeResolver);
        }

        public ScopeItemResolveContext CreateChildScope(IReadOnlyList<FirstPhaseResolvedImportPath> importPaths)
        {
            var typeResolver = this.TypeResolver.CreateScopeWithImportPathLayer(importPaths);

            return new ScopeItemResolveContext(typeResolver);
        }
    }
}
