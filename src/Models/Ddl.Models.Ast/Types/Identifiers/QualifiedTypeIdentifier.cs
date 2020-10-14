using TheToolsmiths.Ddl.Models.Ast.Types.TypePaths.Identifiers;

namespace TheToolsmiths.Ddl.Models.Ast.Types.Identifiers
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
