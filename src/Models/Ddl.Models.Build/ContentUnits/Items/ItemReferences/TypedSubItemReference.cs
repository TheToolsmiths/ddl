using TheToolsmiths.Ddl.Models.Build.References.ItemReferences;
using TheToolsmiths.Ddl.Models.Build.Types.Names;

namespace TheToolsmiths.Ddl.Models.Build.ContentUnits.Items.ItemReferences
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
