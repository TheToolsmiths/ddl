using TheToolsmiths.Ddl.Models.Compiled.References.ItemReferences;
using TheToolsmiths.Ddl.Models.Compiled.Types.Names;

namespace TheToolsmiths.Ddl.Models.Compiled.ContentUnits.Items.ItemReferences
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
