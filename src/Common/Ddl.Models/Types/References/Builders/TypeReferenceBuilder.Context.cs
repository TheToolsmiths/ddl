using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Models.Types.References.Builders
{
    public partial class TypeReferenceBuilder
    {
        internal class Context
        {
            public List<TypeReference> BuiltReferences { get; } = new List<TypeReference>();
        }
    }
}
