using TheToolsmiths.Ddl.Models.Types;

namespace TheToolsmiths.Ddl.Models.Values
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
