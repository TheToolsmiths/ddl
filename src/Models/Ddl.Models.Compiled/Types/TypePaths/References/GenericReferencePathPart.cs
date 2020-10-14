using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Compiled.Paths;

namespace TheToolsmiths.Ddl.Models.Compiled.Types.TypePaths.References
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

        public override PathPartKind PartKind => PathPartKind.Generic;

        public int GenericParametersCount { get; }

        public IReadOnlyList<int> ParameterTypesIndices { get; }

        public override string ToString()
        {
            return PathHelpers.ToGenericIdentifier(this.Name, this.ParameterTypesIndices.Count);
        }
    }
}
