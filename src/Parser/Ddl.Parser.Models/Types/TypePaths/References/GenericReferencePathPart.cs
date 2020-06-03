using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.References
{
    public class GenericReferencePathPart : TypeReferencePathPart
    {
        public GenericReferencePathPart(Identifier name, int genericParametersCount, IReadOnlyList<int> typesIndices)
            : base(name)
        {
            this.GenericParametersCount = genericParametersCount;
            this.TypesIndices = typesIndices;
        }

        public override TypeReferencePathPartKind PartKind => TypeReferencePathPartKind.Generic;

        public int GenericParametersCount { get; }

        public IReadOnlyList<int> TypesIndices { get; }

        public override string ToString()
        {
            return $"{this.Name}<{new string(',', this.GenericParametersCount)}>";
        }
    }
}
