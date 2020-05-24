using System.Collections.Generic;
using System.Linq;

namespace TheToolsmiths.Ddl.Parser.Models.TypePaths.Identifiers
{
    public class ResolvedTypeIdentifierPath
    {
        private ResolvedTypeIdentifierPath(bool isRooted, IReadOnlyList<ResolvedTypeIdentifierPathPart> pathParts)
        {
            this.IsRooted = isRooted;
            this.PathParts = pathParts;
        }

        public IReadOnlyList<ResolvedTypeIdentifierPathPart> PathParts { get; }

        public bool IsRooted { get; }

        public static ResolvedTypeIdentifierPath CreateFromParts(IReadOnlyList<ResolvedTypeIdentifierPathPart> pathParts)
        {
            return new ResolvedTypeIdentifierPath(false, pathParts);
        }

        public static ResolvedTypeIdentifierPath CreateRootedFromParts(IReadOnlyList<ResolvedTypeIdentifierPathPart> pathParts)
        {
            return new ResolvedTypeIdentifierPath(true, pathParts);
        }

        public override string ToString()
        {
            return $"{(this.IsRooted ? "::" : "")}{string.Join("::", this.PathParts.Select(pp => pp.ToString()))}";
        }
    }
}
