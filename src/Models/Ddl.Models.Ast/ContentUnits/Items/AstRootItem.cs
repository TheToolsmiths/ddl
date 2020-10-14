using TheToolsmiths.Ddl.Models.Ast.EntryTypes;

namespace TheToolsmiths.Ddl.Models.Ast.ContentUnits.Items
{
    public abstract class AstRootItem : IAstRootItem
    {
        public abstract AstItemType ItemType { get; }
    }
}
