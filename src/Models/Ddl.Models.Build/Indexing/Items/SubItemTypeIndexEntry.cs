using TheToolsmiths.Ddl.Models.Build.Items.References;
using TheToolsmiths.Ddl.Models.Types.Items;

namespace TheToolsmiths.Ddl.Models.Build.Indexing.Items
{
    public class SubItemTypeIndexEntry
    {
        public SubItemTypeIndexEntry(SubItemTypeName typeName, SubItemReference subItemReference)
        {
            this.SubItemReference = subItemReference;
            this.TypeName = typeName;
        }

        public SubItemTypeName TypeName { get; }

        public SubItemReference SubItemReference { get; }
    }
}
