using TheToolsmiths.Ddl.Models.Compiled.Types.Usage;
using TheToolsmiths.Ddl.Models.Compiled.Values;

namespace TheToolsmiths.Ddl.Models.Compiled.AttributeUsage
{
    public class CompiledKeyedTypedAttributeUse : BaseCompiledTypedAttributeUse, ICompiledKeyedTypedAttributeUse
    {
        public CompiledKeyedTypedAttributeUse(string key, ResolvedTypeUse type, CompiledStructInitialization initialization)
            : base(type, initialization)
        {
            this.Key = key;
        }

        public CompiledKeyedTypedAttributeUse(string key, CompiledTypedStructInitialization initialization)
            : this(key, initialization.Type, initialization.Initialization)
        {
        }

        public override CompiledAttributeUseKind UseKind => CompiledAttributeUseKind.KeyedTyped;

        public override bool IsKeyed => true;

        public override bool IsTyped => true;

        public string Key { get; }
    }
}
