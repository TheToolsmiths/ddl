using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Models.ContentUnits.Scopes
{
    public class RootScope : RootScopeBase
    {
        public RootScope(ScopeContent content, AttributeUseCollection attributes)
            : base(content, attributes)
        {
        }

        public override ScopeType ScopeType => CommonScopeTypes.RootScope;
    }
}
