using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Entries;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items
{
    public interface IAstRootItem : IAstRootEntry
    {
        ContentUnitItemType ItemType { get; }
    }
}
