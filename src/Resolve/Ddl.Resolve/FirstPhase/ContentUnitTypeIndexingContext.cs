using System.Collections.Generic;
using Ddl.Common.Models;
using Ddl.Resolve.Models.FirstPhase;
using Ddl.Resolve.Models.FirstPhase.TypePaths;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase
{
    public class ContentUnitTypeIndexingContext
    {
        private ContentUnitTypeIndexingContext(in ContentUnitId contentUnitId, FirstPhaseNamespacePath namespacePath)
        {
            this.ContentUnitId = contentUnitId;
            this.NamespacePath = namespacePath;

            this.IndexedTypes = new List<IndexedTypeReference>();
        }

        public ContentUnitId ContentUnitId { get; }

        public FirstPhaseNamespacePath NamespacePath { get; }

        public List<IndexedTypeReference> IndexedTypes { get; }

        public static ContentUnitTypeIndexingContext FromContentUnit(FirstPhaseResolvedContentUnit contentUnit)
        {
            return new ContentUnitTypeIndexingContext(contentUnit.Id, contentUnit.NamespacePath);
        }
    }
}
