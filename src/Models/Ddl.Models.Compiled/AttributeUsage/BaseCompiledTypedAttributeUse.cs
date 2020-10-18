using TheToolsmiths.Ddl.Models.Compiled.Types.Usage;
using TheToolsmiths.Ddl.Models.Compiled.Values;

namespace TheToolsmiths.Ddl.Models.Compiled.AttributeUsage
{
    public abstract class BaseCompiledTypedAttributeUse : BaseCompiledStructInitializationAttributeUse, ICompiledTypedAttributeUse
    {
        protected BaseCompiledTypedAttributeUse(
            ResolvedTypeUse type,
            CompiledStructInitialization initialization)
        : base(initialization)
        {
            this.Type = type;
        }

        public ResolvedTypeUse Type { get; }

        public override CompiledAttributeUseKind UseKind => CompiledAttributeUseKind.Typed;

        public override bool IsTyped => true;
    }
}
