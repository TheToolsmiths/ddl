using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Models.Compiled.Scopes
{
    public interface ICompiledScope
    {
        CompiledScopeContent Content { get; }

        ScopeType ScopeType { get; }
    }
}
