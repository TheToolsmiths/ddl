using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.Indexing.Items;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Results;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer
{
    public class RootItemIndexResultBuilder
    {
        public RootItemIndexResultBuilder()
        {
            this.SubItemTypes = new List<SubItemTypeIndexEntry>();
        }

        public List<SubItemTypeIndexEntry> SubItemTypes { get; }

        public ItemTypeIndexEntry? ItemType { get; set; }

        public RootItemIndexResult CreateSuccessResult()
        {
            return new RootItemIndexSuccess(this.ItemType, this.SubItemTypes);
        }
    }
}
