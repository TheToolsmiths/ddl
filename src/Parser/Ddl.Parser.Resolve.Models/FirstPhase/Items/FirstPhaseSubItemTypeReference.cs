using Ddl.Parser.Resolve.Models.Common.ItemReferences;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Paths;

namespace Ddl.Parser.Resolve.Models.FirstPhase.Items
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
