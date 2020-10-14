using System.Collections.Generic;
using System.Linq;

namespace TheToolsmiths.Ddl.Models.Ast.Types.TypePaths.Identifiers
{
    public class TypeIdentifierPath
    {
        private TypeIdentifierPath(bool isRooted, IReadOnlyList<TypeIdentifierPathPart> pathParts)
        {
            this.IsRooted = isRooted;
            this.PathParts = pathParts;
        }

        public IReadOnlyList<TypeIdentifierPathPart> PathParts { get; }

        public bool IsRooted { get; }

        public static TypeIdentifierPath CreateFromParts(IReadOnlyList<TypeIdentifierPathPart> pathParts)
        {
            return new TypeIdentifierPath(false, pathParts);
        }

        public static TypeIdentifierPath CreateRootedFromParts(IReadOnlyList<TypeIdentifierPathPart> pathParts)
        {
            return new TypeIdentifierPath(true, pathParts);
        }

        public override string ToString()
        {
            return $"{(this.IsRooted ? "::" : "")}{string.Join("::", this.PathParts.Select(pp => pp.ToString()))}";
        }
    }
}
