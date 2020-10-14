using TheToolsmiths.Ddl.Models.Build.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Contexts;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Results;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer.Indexers.Wrappers
{
    internal class RootItemIndexerWrapper<TIndexer, TItem> : RootItemIndexerWrapper
        where TIndexer : IRootItemIndexer<TItem>
        where TItem : class, IRootItem
    {
        private readonly TIndexer builder;

        public RootItemIndexerWrapper(TIndexer builder)
        {
            this.builder = builder;
        }

        public override RootItemIndexResult IndexItem(IRootItemIndexContext context, IRootItem item)
        {
            return this.builder.IndexItem(context, (TItem)item);
        }
    }

    internal abstract class RootItemIndexerWrapper
    {
        public abstract RootItemIndexResult IndexItem(IRootItemIndexContext context, IRootItem item);
    }
}
