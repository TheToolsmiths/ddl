using TheToolsmiths.Ddl.Models.Compiled.AttributeUsage;

namespace TheToolsmiths.Ddl.Models.Compiled.Scopes
{
    public interface IAttributableCompiledScope : ICompiledScope
    {
        CompiledAttributeUseCollection Attributes { get; }
    }
}
