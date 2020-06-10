using TheToolsmiths.Ddl.Models;

namespace TheToolsmiths.Ddl.Parser.Models.References.ItemReferences
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
