using TheToolsmiths.Ddl.Parser.Models.Types.Paths;

namespace Ddl.Parser.Resolve.Models.Common.TypeResolve
{
    public class UnresolvedType : ResolvedType
    {
        public UnresolvedType(TypeIdentifierPath typePath)
        {
            this.TypePath = typePath;
        }

        public override ResolvedTypeKind ResolvedKind => ResolvedTypeKind.Unresolved;

        public TypeIdentifierPath TypePath { get; }
    }
}