using TheToolsmiths.Ddl.Models.Build.ContentUnits.Scopes;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.Results
{
    public class RootScopeTypeResolveSuccess : RootScopeTypeResolveResult
    {
        public RootScopeTypeResolveSuccess(IRootScope resolvedScope)
            : base(RootScopeTypeResolveResultKind.Success)
        {
            this.ResolvedScope = resolvedScope;
        }

        public IRootScope ResolvedScope { get; }
    }
}
