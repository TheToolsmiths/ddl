using TheToolsmiths.Ddl.Models.Compiled.Types.Usage;

namespace TheToolsmiths.Ddl.Models.Compiled.Values
{
    public class CompiledTypedStructInitialization : CompiledValueInitialization
    {
        public CompiledTypedStructInitialization(ResolvedTypeUse type, CompiledStructInitialization initialization)
        {
            this.Type = type;
            this.Initialization = initialization;
        }

        public ResolvedTypeUse Type { get; }

        public CompiledStructInitialization Initialization { get; }

        public override CompiledValueInitializationType InitializationKind => CompiledValueInitializationType.TypedStruct;
    }
}
