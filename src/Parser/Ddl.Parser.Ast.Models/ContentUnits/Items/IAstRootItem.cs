using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Entries;
using TheToolsmiths.Ddl.Parser.Ast.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items
{
    public interface IAstRootItem : IAstRootEntry
    {
        AstItemType ItemType { get; }
    }
}
