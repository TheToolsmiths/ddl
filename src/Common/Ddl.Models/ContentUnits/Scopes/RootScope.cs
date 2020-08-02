using TheToolsmiths.Ddl.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Models.ContentUnits.Scopes
{
    public class RootScope : RootScopeBase
    {
        public RootScope(ScopeContent content) : base(content)
        {
        }

        public override ScopeType ScopeType => CommonScopeTypes.RootScope;
    }
}
