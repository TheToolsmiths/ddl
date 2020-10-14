using TheToolsmiths.Ddl.Models.Compiled.EntryTypes;

namespace TheToolsmiths.Ddl.Models.Compiled.ContentUnits.Scopes
{
    public interface IRootScope
    {
        ScopeContent Content { get; }

        ScopeType ScopeType { get; }
    }
}
