using TheToolsmiths.Ddl.Models.Build.References.ItemReferences;
using TheToolsmiths.Ddl.Models.Build.Types.Names;

namespace TheToolsmiths.Ddl.Models.Build.ContentUnits.Items.ItemReferences
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
