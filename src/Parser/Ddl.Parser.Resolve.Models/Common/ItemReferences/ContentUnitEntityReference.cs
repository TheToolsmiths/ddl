using Ddl.Common.Models;

namespace Ddl.Parser.Resolve.Models.Common.ItemReferences
{
    public abstract class ContentUnitEntityReference
    {
        protected ContentUnitEntityReference(ContentUnitId contentUnitId)
        {
            this.ContentUnitId = contentUnitId;
        }

        public ContentUnitId ContentUnitId { get; }

        public abstract override string ToString();
    }
}
