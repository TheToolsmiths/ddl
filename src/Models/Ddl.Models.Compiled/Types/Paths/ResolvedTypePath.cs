using System.Collections.Generic;
using System.Collections.Immutable;

using TheToolsmiths.Ddl.Models.Paths;

namespace TheToolsmiths.Ddl.Models.Compiled.Types.Paths
{
    public class ResolvedTypePath : IPath<ResolvedTypePathPart>
    {
        private ResolvedTypePath(ImmutableArray<ResolvedTypePathPart> pathParts)
        {
            this.PathParts = pathParts;
        }

        public ImmutableArray<ResolvedTypePathPart> PathParts { get; }

        public bool IsRooted => true;

        public static ResolvedTypePath CreateRootedFromParts(IReadOnlyList<ResolvedTypePathPart> pathParts)
        {
            return new ResolvedTypePath(pathParts.ToImmutableArray());
        }

        public override string ToString()
        {
            return PathHelpers.ToQualifiedString(this.IsRooted, this.PathParts);
        }
    }
}
