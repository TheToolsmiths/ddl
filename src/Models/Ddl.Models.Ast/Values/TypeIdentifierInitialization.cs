using TheToolsmiths.Ddl.Models.Ast.Types.Identifiers;

namespace TheToolsmiths.Ddl.Models.Ast.Values
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
