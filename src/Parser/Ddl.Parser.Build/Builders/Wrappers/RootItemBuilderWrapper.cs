using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Parser.Build.Results;

namespace TheToolsmiths.Ddl.Parser.Build.Builders.Wrappers
{
    internal class RootItemBuilderWrapper<TBuilder, TAstItem> : IRootItemBuilderWrapper
        where TBuilder : IRootItemBuilder<TAstItem>
        where TAstItem : class, IAstRootItem
    {
        private readonly TBuilder builder;

        public RootItemBuilderWrapper(TBuilder builder)
        {
            this.builder = builder;
        }

        public RootItemBuildResult BuildItem(IRootItemBuildContext context, IAstRootItem item)
        {
            return this.builder.BuildItem(context, (TAstItem)item);
        }
    }
}
