using TheToolsmiths.Ddl.Parser.Models.Types;

namespace TheToolsmiths.Ddl.Parser.Models.Values
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
