using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Paths;
using TheToolsmiths.Ddl.Models.Types.Usage;

namespace TheToolsmiths.Ddl.Models.Types.Paths
{
    public class GenericPathPart : TypePathPart
    {
        public GenericPathPart(
            string name,
            IReadOnlyList<TypeUse> parameterTypes)
            : base(name)
        {
            this.ParameterTypes = parameterTypes;
        }

        public override PathPartKind PartKind => PathPartKind.Generic;

        public IReadOnlyList<TypeUse> ParameterTypes { get; }

        public override string ToString()
        {
            throw new NotImplementedException();

            //return PathHelpers.ToGenericIdentifier(this.Name, this.ParameterTypesIndices.Count);
        }
    }
}
