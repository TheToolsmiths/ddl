using TheToolsmiths.Ddl.Models.Compiled.AttributeUsage;

namespace TheToolsmiths.Ddl.Models.Compiled.Items
{
    public interface IAttributableCompiledSubItem : ICompiledSubItem
    {
        CompiledAttributeUseCollection Attributes { get; }
    }
}
