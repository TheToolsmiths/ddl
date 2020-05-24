using TheToolsmiths.Ddl.Parser.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Models.TypePaths.References
{
    public class GenericReferencePathPart : TypeReferencePathPart
    {
        public GenericReferencePathPart(Identifier name, int genericParametersCount)
            : base(name)
        {
            this.GenericParametersCount = genericParametersCount;
        }

        public override TypeReferencePathPartKind PartKind => TypeReferencePathPartKind.Generic;

        public int GenericParametersCount { get; }

        public override string ToString()
        {
            return $"{this.Name}<{new string(',', this.GenericParametersCount)}>";
        }
    }
}
