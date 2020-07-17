using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.ContentUnits.Items.ItemReferences;
using TheToolsmiths.Ddl.Models.Types.Names;

namespace TheToolsmiths.Ddl.Parser.Build.Contexts
{
    public class RootItemsBuilder
    {
        public RootItemsBuilder()
        {
            this.SubItemTypesReferences = new List<TypedSubItemReference>();
        }

        public List<TypedSubItemReference> SubItemTypesReferences { get; }

        public TypedItemReference? RootTypeReference { get; set; }

        public TypedItemName? RootType { get; set; }
    }
}
