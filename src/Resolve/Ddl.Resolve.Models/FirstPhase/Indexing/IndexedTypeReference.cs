using Ddl.Common.Models;
using Ddl.Resolve.Models.FirstPhase.TypePaths;

namespace Ddl.Resolve.Models.FirstPhase.Indexing
{
    public abstract class IndexedTypeReference
    {
        protected IndexedTypeReference(
            FirstPhaseTypeName fullDeclaredTypeName,
            ContentUnitId contentUnitId)
        {
            this.FullDeclaredTypeName = fullDeclaredTypeName;
            this.ContentUnitId = contentUnitId;
        }

        public FirstPhaseTypeName FullDeclaredTypeName { get; }

        public ContentUnitId ContentUnitId { get; }

        public override string ToString()
        {
            return $"{this.ContentUnitId}::{this.FullDeclaredTypeName}";
        }
    }
}
