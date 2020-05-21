using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Entries;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes
{
    public interface IRootScope : IRootEntry
    {
        ContentUnitScopeType ScopeType { get; }
    }
}
