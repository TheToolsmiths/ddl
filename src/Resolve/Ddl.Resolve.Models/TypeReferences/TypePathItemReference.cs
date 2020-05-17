using Ddl.Resolve.Models.ItemReferences;
using TheToolsmiths.Ddl.Parser.Models.Types.Paths;

namespace Ddl.Resolve.Models.TypeReferences
{
    public class TypePathItemReference : TypePathEntityReference
    {
        public TypePathItemReference(TypeReferencePath typeNameReference, ItemReference itemReference)
            : base(typeNameReference)
        {
            this.ItemReference = itemReference;
        }

        public ItemReference ItemReference { get; }

        public override EntityReference EntityReference => this.ItemReference;
    }
}
