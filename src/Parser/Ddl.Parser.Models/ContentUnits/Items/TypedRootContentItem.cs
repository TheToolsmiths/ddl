using Ddl.Common.Models;
using TheToolsmiths.Ddl.Parser.Models.Types;

namespace TheToolsmiths.Ddl.Parser.Models.ContentUnits.Items
{
    public abstract class TypedRootContentItem : ITypedRootContentItem
    {
        protected TypedRootContentItem(ITypeName typeName)
        {
            this.ItemId = ContentUnitItemId.CreateNew();
            this.TypeName = typeName;
        }

        public abstract ContentUnitItemType ItemType { get; }

        public ITypeName TypeName { get; }

        public ContentUnitItemId ItemId { get; }
    }
}
