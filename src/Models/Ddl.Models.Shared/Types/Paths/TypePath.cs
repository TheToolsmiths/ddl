using System.Collections.Generic;
using System.Collections.Immutable;
using TheToolsmiths.Ddl.Models.Paths;

namespace TheToolsmiths.Ddl.Models.Types.Paths
{
    public class TypePath : IPath<TypePathPart>
    {
        protected TypePath(bool isRooted, IReadOnlyList<TypePathPart> pathParts)
        {
            this.IsRooted = isRooted;
            this.PathParts = pathParts.ToImmutableArray();
        }

        public ImmutableArray<TypePathPart> PathParts { get; }

        public bool IsRooted { get; }

        public static TypePath CreateFromParts(IReadOnlyList<TypePathPart> pathParts)
        {
            return new TypePath(false, pathParts);
        }

        public static RootTypePath CreateRootedFromParts(IReadOnlyList<TypePathPart> pathParts)
        {
            return RootTypePath.CreateFromParts(pathParts);
        }

        public override string ToString()
        {
            return PathHelpers.ToQualifiedString(this.IsRooted, this.PathParts);
        }
    }
}
