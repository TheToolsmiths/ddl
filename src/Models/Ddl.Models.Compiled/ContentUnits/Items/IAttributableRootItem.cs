using TheToolsmiths.Ddl.Models.Compiled.AttributeUsage;

namespace TheToolsmiths.Ddl.Models.Compiled.ContentUnits.Items
{
    public interface IAttributableRootItem : IRootItem
    {
        AttributeUseCollection Attributes { get; }
    }
}
