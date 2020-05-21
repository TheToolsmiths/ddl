using Ddl.Parser.Resolve.Models.Common.ItemReferences;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Paths;

namespace Ddl.Parser.Resolve.Models.Common.TypeReferences
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
