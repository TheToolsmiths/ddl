using TheToolsmiths.Ddl.Models.ContentUnits.Items;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.Results
{
    public class RootItemTypeResolveSuccess : RootItemTypeResolveResult
    {
        public RootItemTypeResolveSuccess(IRootItem resolvedItem)
            : base(RootItemTypeResolveResultKind.Success)
        {
            this.ResolvedItem = resolvedItem;
        }

        public IRootItem ResolvedItem { get; }
    }
}
