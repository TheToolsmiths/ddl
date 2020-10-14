using TheToolsmiths.Ddl.Models.Build.EntryTypes;

namespace TheToolsmiths.Ddl.Models.Build.ContentUnits.Scopes
{
    public interface IRootScope
    {
        ScopeContent Content { get; }

        ScopeType ScopeType { get; }
    }
}
