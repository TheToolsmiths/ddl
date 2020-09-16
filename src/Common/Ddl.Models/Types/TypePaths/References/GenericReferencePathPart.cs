using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Types.Names;

namespace TheToolsmiths.Ddl.Models.Types.TypePaths.References
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

        public override TypeNameKind PartKind => TypeNameKind.Generic;

        public int GenericParametersCount { get; }

        public IReadOnlyList<int> ParameterTypesIndices { get; }

        public override string ToString()
        {
            return $"{this.Name}<{string.Join(',', this.ParameterTypesIndices)}>";
        }
    }
}
