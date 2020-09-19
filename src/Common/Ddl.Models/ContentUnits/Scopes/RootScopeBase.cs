using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Models.ContentUnits.Scopes
{
    public abstract class RootScopeBase : IRootScope
    {
        protected RootScopeBase(ScopeContent content, AttributeUseCollection attributes)
        {
            this.Attributes = attributes;
            this.Content = content;
        }

        public AttributeUseCollection Attributes { get; }

        public ScopeContent Content { get; }

        public abstract ScopeType ScopeType { get; }
    }
}
