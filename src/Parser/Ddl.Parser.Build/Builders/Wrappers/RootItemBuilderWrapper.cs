using TheToolsmiths.Ddl.Models.Ast.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Parser.Build.Results;

namespace TheToolsmiths.Ddl.Parser.Build.Builders.Wrappers
{
    internal class RootItemBuilderWrapper<TBuilder, TAstItem> : RootItemBuilderWrapper
        where TBuilder : IRootItemBuilder<TAstItem>
        where TAstItem : class, IAstRootItem
    {
        private readonly TBuilder builder;

        public RootItemBuilderWrapper(TBuilder builder)
        {
            this.builder = builder;
        }

        public override RootItemBuildResult BuildItem(IRootItemBuildContext context, IAstRootItem item)
        {
            return this.builder.BuildItem(context, (TAstItem)item);
        }
    }

    internal abstract class RootItemBuilderWrapper
    {
        public abstract RootItemBuildResult BuildItem(IRootItemBuildContext context, IAstRootItem item);
    }
}
