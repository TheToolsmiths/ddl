using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Models.Compiled.Scopes
{
    public abstract class CompiledScopeBase : ICompiledScope
    {
        protected CompiledScopeBase(CompiledScopeContent content)
        {
            this.Content = content;
        }

        public CompiledScopeContent Content { get; }

        public abstract ScopeType ScopeType { get; }
    }
}
