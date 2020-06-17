using TheToolsmiths.Ddl.Models.References.ItemReferences;
using TheToolsmiths.Ddl.Models.Types.Names;

namespace TheToolsmiths.Ddl.Models.ContentUnits.Items.ItemReferences
{
    public class TypedSubItemReference
    {
        public TypedSubItemReference(TypedSubItemName name, SubItemReference subItemReference)
        {
            this.SubItemReference = subItemReference;
            this.Name = name;
        }

        public TypedSubItemName Name { get; }

        public SubItemReference SubItemReference { get; }
    }
}
