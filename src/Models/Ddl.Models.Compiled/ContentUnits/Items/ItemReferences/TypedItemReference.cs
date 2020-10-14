using TheToolsmiths.Ddl.Models.Compiled.References.ItemReferences;
using TheToolsmiths.Ddl.Models.Compiled.Types.Names;

namespace TheToolsmiths.Ddl.Models.Compiled.ContentUnits.Items.ItemReferences
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
