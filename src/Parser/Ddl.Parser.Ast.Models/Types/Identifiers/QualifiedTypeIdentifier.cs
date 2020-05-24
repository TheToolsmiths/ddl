using TheToolsmiths.Ddl.Parser.Ast.Models.Types.TypePaths.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Types.Identifiers
{
    public class QualifiedTypeIdentifier : ITypeIdentifier
    {
        public QualifiedTypeIdentifier(TypeIdentifierPath typePath)
        {
            this.TypePath = typePath;
        }

        public TypeIdentifierPath TypePath { get; }

        public TypeIdentifierKind Kind => TypeIdentifierKind.QualifiedType;

        public override string ToString()
        {
            return this.TypePath.ToString();
        }
    }
}
