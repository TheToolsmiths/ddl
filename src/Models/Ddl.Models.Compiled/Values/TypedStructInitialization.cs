using TheToolsmiths.Ddl.Models.Compiled.Types.References;

namespace TheToolsmiths.Ddl.Models.Compiled.Values
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
