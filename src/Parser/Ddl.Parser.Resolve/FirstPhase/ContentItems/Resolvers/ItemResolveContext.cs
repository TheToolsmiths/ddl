using System.Collections.Generic;
using Ddl.Parser.Resolve.Models.FirstPhase.Items;
using TheToolsmiths.Ddl.Parser.Models.Types.Names;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase.ContentItems.Resolvers
{
    internal class ItemResolveContext
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
