using TheToolsmiths.Ddl.Parser.Models.TypePaths.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Models.Types
{
    public class UnresolvedType : ResolvedTypePart
    {
        public UnresolvedType(ResolvedTypeIdentifierPath typePath)
        {
            this.TypePath = typePath;
        }

        public override ResolvedTypePartKind ResolvedKind => ResolvedTypePartKind.Unresolved;

        public ResolvedTypeIdentifierPath TypePath { get; }
    }
}
