using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.ContentUnits.Items.ItemReferences;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Results;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer
{
    public class RootItemIndexResultBuilder
    {
        public RootItemIndexResultBuilder()
        {
            this.SubItemTypesReferences = new List<TypedSubItemReference>();
        }

        public List<TypedSubItemReference> SubItemTypesReferences { get; }

        public TypedItemReference? RootTypeReference { get; set; }

        public RootItemIndexResult CreateSuccessResult()
        {
            return new RootItemIndexSuccess(this.RootTypeReference, this.SubItemTypesReferences);
        }
    }
}
