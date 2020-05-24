using TheToolsmiths.Ddl.Parser.Models.Types;

namespace TheToolsmiths.Ddl.Parser.Models.Values
{
    public class TypeIdentifierInitialization : ValueInitialization
    {
        public TypeIdentifierInitialization(ResolvedType type)
        {
            this.Type = type;
        }

        public ResolvedType Type { get; }

        public override ValueInitializationType InitializationKind => ValueInitializationType.TypeIdentifier;
    }
}
