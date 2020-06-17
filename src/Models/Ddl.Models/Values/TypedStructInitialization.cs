using TheToolsmiths.Ddl.Models.Types.References;

namespace TheToolsmiths.Ddl.Models.Values
{
    public class TypedStructInitialization : ValueInitialization
    {
        public TypedStructInitialization(TypeReference type, StructInitialization initialization)
        {
            this.Type = type;
            this.Initialization = initialization;
        }

        public TypeReference Type { get; }

        public StructInitialization Initialization { get; }

        public override ValueInitializationType InitializationKind => ValueInitializationType.TypedStruct;
    }
}
