using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.References
{
    public class GenericReferencePathPart : TypeReferencePathPart
    {
        public GenericReferencePathPart(
            string name,
            int genericParametersCount,
            IReadOnlyList<int> parameterTypesIndices)
            : base(name)
        {
            this.GenericParametersCount = genericParametersCount;
            this.ParameterTypesIndices = parameterTypesIndices;
        }

        public override TypeReferencePathPartKind PartKind => TypeReferencePathPartKind.Generic;

        public int GenericParametersCount { get; }

        public IReadOnlyList<int> ParameterTypesIndices { get; }

        public override string ToString()
        {
            return $"{this.Name}<{string.Join(',', this.ParameterTypesIndices)}>";
        }
    }
}
