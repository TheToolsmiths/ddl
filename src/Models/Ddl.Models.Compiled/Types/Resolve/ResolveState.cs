using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Models.Compiled.Types.Resolve
{
    // TODO: Delete
    public class ResolveState
    {
        public ResolveState(IReadOnlyList<ReferencedTypeResolveState> referencedTypes)
        {
            this.ReferencedTypes = referencedTypes;
        }

        public IReadOnlyList<ReferencedTypeResolveState> ReferencedTypes { get; }
    }
}
