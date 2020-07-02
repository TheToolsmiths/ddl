using TheToolsmiths.Ddl.Parser.Ast.Models.EntryTypes;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Names;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items
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
