using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Models.Build.Scopes
{
    public interface IRootScope
    {
        ScopeContent Content { get; }

        ScopeType ScopeType { get; }
    }
}
