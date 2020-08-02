using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Models.ContentUnits.Scopes
{
    public interface IRootScope
    {
        ScopeContent Content { get; }

        ScopeType ScopeType { get; }
    }
}
