using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Entries;

namespace TheToolsmiths.Ddl.Parser.Models.ContentUnits.Scopes
{
    public interface IRootScope : IRootContentEntry
    {
        ContentUnitScopeType ScopeType { get; }
    }
}
