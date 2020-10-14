using TheToolsmiths.Ddl.Models.Ast.ContentUnits.Entries;
using TheToolsmiths.Ddl.Models.Ast.EntryTypes;

namespace TheToolsmiths.Ddl.Models.Ast.ContentUnits.Items
{
    public interface IAstRootItem : IAstRootEntry
    {
        AstItemType ItemType { get; }
    }
}
