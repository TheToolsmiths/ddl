using System.Collections.Generic;
using Ddl.Resolve.Models.FirstPhase;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase
{
    public class ContentUnitsCollectionResolveContext
    {
        public List<FirstPhaseResolvedContentUnit> ContentUnits { get; } = new List<FirstPhaseResolvedContentUnit>();

        public List<IndexedTypeReference> IndexedTypes { get; } = new List<IndexedTypeReference>();
    }
}
