using System.Collections.Generic;
using Ddl.Common.Models;
using Ddl.Resolve.Models.FirstPhase.Indexing;
using Ddl.Resolve.Models.FirstPhase.Scopes;
using Ddl.Resolve.Models.FirstPhase.TypePaths;

namespace Ddl.Resolve.Models.FirstPhase
{
    public class FirstPhaseResolvedContentUnit
    {
        public FirstPhaseResolvedContentUnit(
            ContentUnitId id,
            FirstPhaseNamespacePath namespacePath,
            FirstPhaseResolvedScope rootScope,
            IReadOnlyList<IndexedTypeReference> indexedTypes)
        {
            this.Id = id;
            this.RootScope = rootScope;
            this.IndexedTypes = indexedTypes;
            this.NamespacePath = namespacePath;
        }

        public ContentUnitId Id { get; }

        public FirstPhaseResolvedScope RootScope { get; }

        public IReadOnlyList<IndexedTypeReference> IndexedTypes { get; }

        public FirstPhaseNamespacePath NamespacePath { get; }
    }
}
