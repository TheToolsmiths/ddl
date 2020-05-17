using Ddl.Common.Models;
using TheToolsmiths.Ddl.Parser.Models.Types;
using TheToolsmiths.Ddl.Parser.Models.Types.Names;

namespace TheToolsmiths.Ddl.Parser.Models.ContentUnits.Items
{
    public abstract class TypedRootItem : ITypedRootItem
    {
        protected TypedRootItem(ITypeName typeName)
        {
            this.ItemId = ContentUnitItemId.CreateNew();
            this.TypeName = typeName;
        }

        public abstract ContentUnitItemType ItemType { get; }

        public ITypeName TypeName { get; }

        public ContentUnitItemId ItemId { get; }
    }
}
