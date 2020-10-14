using TheToolsmiths.Ddl.Models.Build.EntryTypes;

namespace TheToolsmiths.Ddl.Models.Build.ContentUnits.Scopes
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
