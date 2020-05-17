using Ddl.Resolve.Models.ItemReferences;
using TheToolsmiths.Ddl.Parser.Models.Types.Paths;

namespace Ddl.Resolve.Models.TypeReferences
{
    public abstract class TypePathEntityReference
    {
        protected TypePathEntityReference(TypeReferencePath typeNameReference)
        {
            this.TypeNameReference = typeNameReference;
        }

        public TypeReferencePath TypeNameReference { get; }

        public abstract EntityReference EntityReference { get; }

        public override string ToString()
        {
            return $"{this.EntityReference} > {this.TypeNameReference}";
        }
    }
}
