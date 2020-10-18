using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.Indexing.Items;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer.Results
{
    public class RootItemIndexSuccess : RootItemIndexResult
    {
        public RootItemIndexSuccess(
            ItemTypeIndexEntry? itemTypeReference,
            IReadOnlyList<SubItemTypeIndexEntry> subItemTypesReferences)
            : base(RootItemIndexResultKind.Success)
        {
            this.ItemTypeReference = itemTypeReference;
            this.SubItemTypesReferences = subItemTypesReferences;
        }

        public ItemTypeIndexEntry? ItemTypeReference { get; }

        public IReadOnlyList<SubItemTypeIndexEntry> SubItemTypesReferences { get; }
    }
}
