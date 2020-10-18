using TheToolsmiths.Ddl.Models.Build.Types.Usage;

namespace TheToolsmiths.Ddl.Models.Build.Values
{
    public class TypedStructInitialization : ValueInitialization
    {
        public TypedStructInitialization(TypeUse type, StructInitialization initialization)
        {
            this.Type = type;
            this.Initialization = initialization;
        }

        public TypeUse Type { get; }

        public StructInitialization Initialization { get; }

        public override ValueInitializationType InitializationKind => ValueInitializationType.TypedStruct;
    }
}
