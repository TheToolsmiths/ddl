using Ddl.Resolve.Models.ItemReferences;
using TheToolsmiths.Ddl.Parser.Models.Types.Paths;

namespace Ddl.Resolve.Models.FirstPhase.Items
{
    public class FirstPhaseSubItemTypeReference
    {
        public FirstPhaseSubItemTypeReference(TypeReferencePath typePath, SubItemReference subItemReference)
        {
            this.SubItemReference = subItemReference;
            this.TypePath = typePath;
        }

        public TypeReferencePath TypePath { get; }

        public SubItemReference SubItemReference { get; }
    }
}
