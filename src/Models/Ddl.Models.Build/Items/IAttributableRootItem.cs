using TheToolsmiths.Ddl.Models.Build.AttributeUsage;

namespace TheToolsmiths.Ddl.Models.Build.Items
{
    public interface IAttributableRootItem : IRootItem
    {
        AttributeUseCollection Attributes { get; }
    }
}
