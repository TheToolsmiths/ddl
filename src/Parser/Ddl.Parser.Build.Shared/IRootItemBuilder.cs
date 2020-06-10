using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Parser.Build.Results;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Items;

namespace TheToolsmiths.Ddl.Parser.Build
{
    public interface IRootItemBuilder<T>
        where T : class, IRootItem
    {
        public RootItemBuildResult<T> BuildItem(IRootItemBuildContext unitContext, Ast.Models.ContentUnits.Items.IAstRootItem item);
    }
}
