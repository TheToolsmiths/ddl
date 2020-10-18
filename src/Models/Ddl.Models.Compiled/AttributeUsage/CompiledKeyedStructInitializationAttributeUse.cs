using TheToolsmiths.Ddl.Models.Compiled.Values;

namespace TheToolsmiths.Ddl.Models.Compiled.AttributeUsage
{
    public class CompiledKeyedStructInitializationAttributeUse : BaseCompiledStructInitializationAttributeUse, ICompiledKeyedStructInitializationAttributeUse
    {
        public CompiledKeyedStructInitializationAttributeUse(string key, CompiledStructInitialization initialization)
            : base(initialization)
        {
            this.Key = key;
        }

        public override CompiledAttributeUseKind UseKind => CompiledAttributeUseKind.KeyedStructInitialization;

        public override bool IsKeyed => true;

        public override bool IsTyped => false;

        public string Key { get; }
    }
}
