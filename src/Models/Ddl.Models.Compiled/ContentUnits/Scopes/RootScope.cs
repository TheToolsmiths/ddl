using TheToolsmiths.Ddl.Models.Compiled.AttributeUsage;
using TheToolsmiths.Ddl.Models.Compiled.EntryTypes;

namespace TheToolsmiths.Ddl.Models.Compiled.ContentUnits.Scopes
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
