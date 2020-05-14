using System.Collections.Generic;
using Ddl.Common.Models;
using Ddl.Resolve.Models.FirstPhase.Indexing;
using Ddl.Resolve.Models.FirstPhase.TypePaths;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase
{
    internal class ContentUnitTypeIndexingContext
    {
        public ContentUnitTypeIndexingContext(in ContentUnitId contentUnitId, FirstPhaseNamespacePath namespacePath)
        {
            this.ContentUnitId = contentUnitId;
            this.NamespacePath = namespacePath;

            this.IndexedTypes = new List<IndexedTypeReference>();
        }

        public ContentUnitId ContentUnitId { get; }

        public FirstPhaseNamespacePath NamespacePath { get; }

        public List<IndexedTypeReference> IndexedTypes { get; }
    }
}
