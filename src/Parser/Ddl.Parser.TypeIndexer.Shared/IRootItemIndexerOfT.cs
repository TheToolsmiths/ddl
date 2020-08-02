﻿using TheToolsmiths.Ddl.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Contexts;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Results;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer
{
    public interface IRootItemIndexer<TItem> : IRootItemIndexer
        where TItem : class, IRootItem
    {
        public RootItemIndexResult BuildItem(IRootItemIndexContext itemContext, TItem item);
    }

    public interface IRootItemIndexer
    {
    }
}
