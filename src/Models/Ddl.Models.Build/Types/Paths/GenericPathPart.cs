using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.Types.Usage;
using TheToolsmiths.Ddl.Models.Paths;

namespace TheToolsmiths.Ddl.Models.Build.Types.Paths
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
