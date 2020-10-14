using TheToolsmiths.Ddl.Models.Ast.EntryTypes;
using TheToolsmiths.Ddl.Models.Ast.Types.Names;

namespace TheToolsmiths.Ddl.Models.Ast.ContentUnits.Items
{
    public abstract class AstTypedRootItem : IAstTypedRootItem
    {
        protected AstTypedRootItem(TypeName typeName)
        {
            this.TypeName = typeName;
        }

        public abstract AstItemType ItemType { get; }

        public TypeName TypeName { get; }
    }
}
