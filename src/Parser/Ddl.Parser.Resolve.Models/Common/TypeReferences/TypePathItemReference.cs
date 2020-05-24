using Ddl.Parser.Resolve.Models.Common.ItemReferences;
using TheToolsmiths.Ddl.Parser.Models.TypePaths.References;

namespace Ddl.Parser.Resolve.Models.Common.TypeReferences
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
