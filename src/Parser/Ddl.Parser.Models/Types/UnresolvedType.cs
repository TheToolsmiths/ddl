using TheToolsmiths.Ddl.Parser.Models.TypePaths.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Models.Types
{
    public class UnresolvedType : ResolvedType
    {
        public UnresolvedType(ResolvedTypeIdentifierPath typePath)
        {
            this.TypePath = typePath;
        }

        public override ResolvedTypeKind ResolvedKind => ResolvedTypeKind.Unresolved;

        public ResolvedTypeIdentifierPath TypePath { get; }
    }
}
