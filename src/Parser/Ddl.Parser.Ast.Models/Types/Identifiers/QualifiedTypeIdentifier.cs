using TheToolsmiths.Ddl.Parser.Ast.Models.Types.TypePaths.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Types.Identifiers
{
    public class QualifiedTypeIdentifier : ITypeIdentifier,
        IReferenceableTypeIdentifier,
        IGenericParameterTypeIdentifier,
        IModifiableTypeIdentifier
    {
        public QualifiedTypeIdentifier(TypeIdentifierPath typePath)
        {
            this.TypePath = typePath;
        }

        public TypeIdentifierPath TypePath { get; }

        public override string ToString()
        {
            return this.TypePath.ToString();
        }
    }
}
