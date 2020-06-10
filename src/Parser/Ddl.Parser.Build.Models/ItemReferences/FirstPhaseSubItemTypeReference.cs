using TheToolsmiths.Ddl.Parser.Models.References.ItemReferences;
using TheToolsmiths.Ddl.Parser.Models.Types.Names;

namespace TheToolsmiths.Ddl.Parser.Build.Models.ItemReferences
{
    public class FirstPhaseSubItemTypeReference
    {
        public FirstPhaseSubItemTypeReference(SubItemTypeName typeName, SubItemReference subItemReference)
        {
            this.SubItemReference = subItemReference;
            this.TypeName = typeName;
        }

        public SubItemTypeName TypeName { get; }

        public SubItemReference SubItemReference { get; }
    }
}
