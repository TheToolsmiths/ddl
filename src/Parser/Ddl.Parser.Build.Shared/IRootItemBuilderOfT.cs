using TheToolsmiths.Ddl.Models.Ast.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Parser.Build.Results;

namespace TheToolsmiths.Ddl.Parser.Build
{
    public interface IRootItemBuilder<TAstItem> : IRootItemBuilder
        where TAstItem : class, IAstRootItem
    {
        public RootItemBuildResult BuildItem(IRootItemBuildContext itemContext, TAstItem item);
    }

    public interface IRootItemBuilder
    {
    }
}
