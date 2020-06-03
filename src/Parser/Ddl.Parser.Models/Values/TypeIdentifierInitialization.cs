using TheToolsmiths.Ddl.Parser.Models.Types.References;

namespace TheToolsmiths.Ddl.Parser.Models.Values
{
    public class TypeIdentifierInitialization : ValueInitialization
    {
        public TypeIdentifierInitialization(TypeReference type)
        {
            this.Type = type;
        }

        public TypeReference Type { get; }

        public override ValueInitializationType InitializationKind => ValueInitializationType.TypeIdentifier;
    }
}
