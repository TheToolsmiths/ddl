using TheToolsmiths.Ddl.Models.Compiled.Values;

namespace TheToolsmiths.Ddl.Models.Compiled.AttributeUsage
{
    public abstract class BaseCompiledStructInitializationAttributeUse : BaseCompiledAttributeUse, ICompiledStructInitializationAttributeUse
    {
        protected BaseCompiledStructInitializationAttributeUse(CompiledStructInitialization initialization)
        {
            this.Initialization = initialization;
        }

        public CompiledStructInitialization Initialization { get; }

        public abstract override CompiledAttributeUseKind UseKind { get; }

        public override bool IsTyped => false;
    }
}
