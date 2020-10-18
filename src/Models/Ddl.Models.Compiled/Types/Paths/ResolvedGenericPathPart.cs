using System;
using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.Compiled.Types.Usage;
using TheToolsmiths.Ddl.Models.Paths;

namespace TheToolsmiths.Ddl.Models.Compiled.Types.Paths
{
    public class ResolvedGenericPathPart : ResolvedTypePathPart
    {
        public ResolvedGenericPathPart(
            string name,
            IReadOnlyList<ResolvedTypeUse> parameterTypes)
            : base(name)
        {
            this.ParameterTypes = parameterTypes;
        }

        public override PathPartKind PartKind => PathPartKind.Generic;

        public IReadOnlyList<ResolvedTypeUse> ParameterTypes { get; }

        public override string ToString()
        {
            throw new NotImplementedException();

            //return PathHelpers.ToGenericIdentifier(this.Name, this.ParameterTypesIndices.Count);
        }
    }
}
