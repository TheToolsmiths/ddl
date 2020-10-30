using TheToolsmiths.Ddl.Models.Compiled.Types.Usage;
using TheToolsmiths.Ddl.Models.Compiled.Values;

namespace TheToolsmiths.Ddl.Models.Compiled.AttributeUsage
{
    public class CompiledTypedInitializationUse : BaseCompiledTypedAttributeUse
    {
        public CompiledTypedInitializationUse(
            ResolvedTypeUse type, 
            CompiledStructInitialization initialization)
            : base(type, initialization)
        {
        }

        public override bool IsKeyed => false;
    }
}
