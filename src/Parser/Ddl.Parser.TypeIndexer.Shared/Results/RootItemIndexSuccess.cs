using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.ContentUnits.Items.ItemReferences;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer.Results
{
    public class RootItemIndexSuccess : RootItemIndexResult
    {
        public RootItemIndexSuccess(
            TypedItemReference? itemTypeReference,
            IReadOnlyList<TypedSubItemReference> subItemTypesReferences)
            : base(RootItemIndexResultKind.Success)
        {
            this.ItemTypeReference = itemTypeReference;
            this.SubItemTypesReferences = subItemTypesReferences;
        }

        public TypedItemReference? ItemTypeReference { get; }

        public IReadOnlyList<TypedSubItemReference> SubItemTypesReferences { get; }
    }
}
