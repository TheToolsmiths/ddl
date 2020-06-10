using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Build.Models.ItemReferences;
using TheToolsmiths.Ddl.Parser.Models.Types.Names;

namespace TheToolsmiths.Ddl.Parser.Build.Contexts
{
    public class ItemResolveContext
    {
        public ItemResolveContext()
        {
            this.SubItemTypesReferences = new List<FirstPhaseSubItemTypeReference>();
            this.RootTypeReference = default!;
            this.RootType = default!;
        }

        public List<FirstPhaseSubItemTypeReference> SubItemTypesReferences { get; }

        public FirstPhaseItemTypeReference RootTypeReference { get; set; }

        public ItemTypeName RootType { get; set; }
    }
}
