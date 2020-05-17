using Ddl.Resolve.Models.ItemReferences;
using TheToolsmiths.Ddl.Parser.Models.Types.Paths;

namespace Ddl.Resolve.Models.FirstPhase.Items
{
    public class FirstPhaseItemTypeReference
    {
        public FirstPhaseItemTypeReference(TypeReferencePath typePath, ItemReference itemReference)
        {
            this.TypePath = typePath;
            this.ItemReference = itemReference;
        }

        public TypeReferencePath TypePath { get; }

        public ItemReference ItemReference { get; }
    }
}
