using TheToolsmiths.Ddl.Models.Build.Items;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Contexts;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Results;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer
{
    public interface IRootItemIndexer<TItem> : IRootItemIndexer
        where TItem : class, IRootItem
    {
        public RootItemIndexResult IndexItem(IRootItemIndexContext itemContext, TItem item);
    }

    public interface IRootItemIndexer
    {
    }
}
