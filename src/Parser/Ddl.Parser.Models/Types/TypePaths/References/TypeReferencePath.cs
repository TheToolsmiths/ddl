using System.Collections.Generic;
using System.Linq;

namespace TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.References
{
    public class TypeReferencePath
    {
        public TypeReferencePath(bool isRooted, IReadOnlyList<TypeReferencePathPart> pathParts)
        {
            this.IsRooted = isRooted;
            this.PathParts = pathParts;
        }

        public IReadOnlyList<TypeReferencePathPart> PathParts { get; }

        public bool IsRooted { get; }

        public static TypeReferencePath CreateFromParts(IReadOnlyList<TypeReferencePathPart> pathParts)
        {
            return new TypeReferencePath(false, pathParts);
        }

        public static TypeReferencePath CreateRootedFromParts(IReadOnlyList<TypeReferencePathPart> pathParts)
        {
            return new TypeReferencePath(true, pathParts);
        }

        public override string ToString()
        {
            return $"{(this.IsRooted ? "::" : "")}{string.Join("::", this.PathParts.Select(pp => pp.ToString()))}";
        }
    }
}
