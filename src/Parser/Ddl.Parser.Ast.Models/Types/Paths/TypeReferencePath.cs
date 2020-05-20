using System.Collections.Generic;
using System.Linq;

namespace TheToolsmiths.Ddl.Parser.Models.Types.Paths
{
    public class TypeReferencePath
    {
        private TypeReferencePath(bool isRooted, IReadOnlyList<TypeReferencePathPart> pathParts)
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

        public static TypeReferencePath CreateFromIdentifierPath(TypeIdentifierPath lookupPath)
        {
            var pathParts = lookupPath.PathParts.Select(TypeReferencePathPart.CreateFromIdentifierPart).ToList();
            return new TypeReferencePath(lookupPath.IsRooted, pathParts);
        }

        public override string ToString()
        {
            return $"{(this.IsRooted ? "::" : "")}{string.Join("::", this.PathParts.Select(pp => pp.ToString()))}";
        }
    }
}
