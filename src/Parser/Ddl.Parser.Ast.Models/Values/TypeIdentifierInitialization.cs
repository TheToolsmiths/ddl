using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Values
{
    public class TypeIdentifierInitialization : ValueInitialization
    {
        public TypeIdentifierInitialization(ITypeIdentifier typeIdentifier)
        {
            this.TypeIdentifier = typeIdentifier;
        }

        public ITypeIdentifier TypeIdentifier { get; }

        public override ValueInitializationType Type => ValueInitializationType.TypeIdentifier;
    }
}
