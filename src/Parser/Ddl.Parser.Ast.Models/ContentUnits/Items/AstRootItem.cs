using TheToolsmiths.Ddl.Parser.Ast.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items
{
    public abstract class AstRootItem : IAstRootItem
    {
        public abstract AstItemType ItemType { get; }
    }
}
