using Ddl.Parser.Resolve.Models.Common.ItemReferences;
using TheToolsmiths.Ddl.Parser.Models.TypePaths.References;

namespace Ddl.Parser.Resolve.Models.Common.TypeReferences
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
