using Ddl.Parser.Resolve.Models.Common.ItemReferences;
using TheToolsmiths.Ddl.Parser.Models.Types.Names;

namespace Ddl.Parser.Resolve.Models.FirstPhase.Items
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
