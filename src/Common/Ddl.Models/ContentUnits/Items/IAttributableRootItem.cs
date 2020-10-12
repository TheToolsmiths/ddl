using TheToolsmiths.Ddl.Models.AttributeUsage;

namespace TheToolsmiths.Ddl.Models.ContentUnits.Items
{
    public interface IAttributableRootItem : IRootItem
    {
        AttributeUseCollection Attributes { get; }
    }
}
