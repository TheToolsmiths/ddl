using Ddl.Resolve.Models.ItemReferences;
using TheToolsmiths.Ddl.Parser.Models.Types.Paths;

namespace Ddl.Resolve.Models.TypeReferences
{
    public class TypePathSubItemReference : TypePathEntityReference
    {
        public TypePathSubItemReference(
            TypeReferencePath typeNameReference,
            SubItemReference subItemReference)
            : base(typeNameReference)
        {
            this.SubItemReference = subItemReference;
        }

        public SubItemReference SubItemReference { get; }

        public override EntityReference EntityReference => this.SubItemReference;
    }
}
