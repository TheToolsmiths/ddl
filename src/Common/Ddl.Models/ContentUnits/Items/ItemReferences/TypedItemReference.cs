using TheToolsmiths.Ddl.Models.References.ItemReferences;
using TheToolsmiths.Ddl.Models.Types.Names;

namespace TheToolsmiths.Ddl.Models.ContentUnits.Items.ItemReferences
{
    public class TypedItemReference
    {
        public TypedItemReference(TypedItemName name, ItemReference itemReference)
        {
            this.Name = name;
            this.ItemReference = itemReference;
        }

        public TypedItemName Name { get; }

        public ItemReference ItemReference { get; }
    }
}
