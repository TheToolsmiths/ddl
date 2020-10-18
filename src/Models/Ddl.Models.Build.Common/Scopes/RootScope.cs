using TheToolsmiths.Ddl.Models.Build.AttributeUsage;
using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Models.Build.Scopes
{
    public class RootScope : RootScopeBase, IAttributableRootScope
    {
        public RootScope(ScopeContent content, AttributeUseCollection attributes)
            : base(content)
        {
            this.Attributes = attributes;
        }

        public override ScopeType ScopeType => CommonScopeTypes.RootScope;

        public AttributeUseCollection Attributes { get; }
    }
}
