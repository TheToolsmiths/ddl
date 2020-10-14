using TheToolsmiths.Ddl.Models.Build.AttributeUsage;

namespace TheToolsmiths.Ddl.Models.Build.ContentUnits.Items
{
    public interface IAttributableRootItem : IRootItem
    {
        AttributeUseCollection Attributes { get; }
    }
}
