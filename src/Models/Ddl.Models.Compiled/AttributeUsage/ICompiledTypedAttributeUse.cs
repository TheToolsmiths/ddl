using TheToolsmiths.Ddl.Models.Compiled.Types.Usage;

namespace TheToolsmiths.Ddl.Models.Compiled.AttributeUsage
{
    public interface ICompiledTypedAttributeUse : ICompiledStructInitializationAttributeUse
    {
        ResolvedTypeUse Type { get; }
    }
}
