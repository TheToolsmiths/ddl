using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Names;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items
{
    public abstract class AstTypedRootItem : IAstTypedRootItem
    {
        protected AstTypedRootItem(TypeName typeName)
        {
            this.TypeName = typeName;
        }

        public abstract ContentUnitItemType ItemType { get; }

        public TypeName TypeName { get; }
    }
}
