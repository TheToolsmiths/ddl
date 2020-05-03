using System.Collections.Generic;
using Ddl.Resolve.Models.FirstPhase;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase
{
    public class FirstPhaseResolvedContent
    {
        public FirstPhaseResolvedContent(
            IReadOnlyList<IndexedTypeReference> indexedTypes,
            IReadOnlyList<FirstPhaseResolvedContentUnit> contentUnits)
        {
            this.IndexedTypes = indexedTypes;
            this.ContentUnits = contentUnits;
        }

        public IReadOnlyList<IndexedTypeReference> IndexedTypes { get; }

        public IReadOnlyList<FirstPhaseResolvedContentUnit> ContentUnits { get; }
    }
}
