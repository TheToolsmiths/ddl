using TheToolsmiths.Ddl.Models.Compiled.AttributeUsage;

namespace TheToolsmiths.Ddl.Models.Compiled.Items
{
    public interface IAttributableCompiledItem : ICompiledItem
    {
        CompiledAttributeUseCollection Attributes { get; }
    }
}
