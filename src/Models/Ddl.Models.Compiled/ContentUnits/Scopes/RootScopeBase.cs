using TheToolsmiths.Ddl.Models.Compiled.EntryTypes;

namespace TheToolsmiths.Ddl.Models.Compiled.ContentUnits.Scopes
{
    public abstract class RootScopeBase : IRootScope
    {
        protected RootScopeBase(ScopeContent content)
        {
            this.Content = content;
        }

        public ScopeContent Content { get; }

        public abstract ScopeType ScopeType { get; }
    }
}
