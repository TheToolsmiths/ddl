using TheToolsmiths.Ddl.Models.Compiled.Values;

namespace TheToolsmiths.Ddl.Models.Compiled.AttributeUsage
{
    public interface ICompiledStructInitializationAttributeUse : ICompiledAttributeUse
    {
        CompiledStructInitialization Initialization { get; }
    }
}
