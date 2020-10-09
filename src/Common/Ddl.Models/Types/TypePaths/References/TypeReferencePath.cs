using System.Collections.Generic;
using System.Collections.Immutable;
using TheToolsmiths.Ddl.Models.Paths;

namespace TheToolsmiths.Ddl.Models.Types.TypePaths.References
{
    public class TypeReferencePath : IQualifiedPath<TypeReferencePathPart>
    {
        protected TypeReferencePath(bool isRooted, IReadOnlyList<TypeReferencePathPart> pathParts)
        {
            this.IsRooted = isRooted;
            this.PathParts = pathParts.ToImmutableArray();
        }

        public ImmutableArray<TypeReferencePathPart> PathParts { get; }

        public bool IsRooted { get; }

        public static TypeReferencePath CreateFromParts(IReadOnlyList<TypeReferencePathPart> pathParts)
        {
            return new TypeReferencePath(false, pathParts);
        }

        public static RootTypeReferencePath CreateRootedFromParts(IReadOnlyList<TypeReferencePathPart> pathParts)
        {
            return RootTypeReferencePath.CreateFromParts(pathParts);
        }

        public override string ToString()
        {
            return PathHelpers.ToQualifiedString(this.IsRooted, this.PathParts);
        }
    }
}
