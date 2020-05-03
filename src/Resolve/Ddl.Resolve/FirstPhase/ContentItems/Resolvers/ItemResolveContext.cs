using System.Collections.Generic;
using Ddl.Resolve.Models.FirstPhase.TypePaths;
using Ddl.Resolve.Models.FirstPhase.TypeReferences;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase.ContentItems.Resolvers
{
    internal class ItemResolveContext
    {
        public ItemResolveContext()
        {
            this.SubItemTypesReferences = new List<FirstPhaseTypePathSubItemReference>();
            this.RootTypeReference = default!;
            this.RootType = default!;
        }

        public List<FirstPhaseTypePathSubItemReference> SubItemTypesReferences { get; }

        public FirstPhaseTypePathItemReference RootTypeReference { get; set; }

        public FirstPhaseTypeName RootType { get; set; }
    }
}
