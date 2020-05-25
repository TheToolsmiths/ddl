using Ddl.Common.Models;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Names;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items
{
    public abstract class TypedRootItem : ITypedRootItem
    {
        protected TypedRootItem(TypeName typeName)
        {
            this.ItemId = ContentUnitItemId.CreateNew();
            this.TypeName = typeName;
        }

        public abstract ContentUnitItemType ItemType { get; }

        public TypeName TypeName { get; }

        public ContentUnitItemId ItemId { get; }
    }
}
