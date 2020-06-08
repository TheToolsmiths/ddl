using TheToolsmiths.Ddl.Parser.Models.References.ItemReferences;
using TheToolsmiths.Ddl.Parser.Models.Types.Names;

namespace Ddl.Parser.Resolve.Models.FirstPhase.Items
{
    public class FirstPhaseItemTypeReference
    {
        public FirstPhaseItemTypeReference(ItemTypeName typeName, ItemReference itemReference)
        {
            this.TypeName = typeName;
            this.ItemReference = itemReference;
        }

        public ItemTypeName TypeName { get; }

        public ItemReference ItemReference { get; }
    }
}
