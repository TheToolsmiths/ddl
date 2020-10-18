using TheToolsmiths.Ddl.Models.Types.Items;

namespace TheToolsmiths.Ddl.Models.Build.Items
{
    public interface INamedRootItem : IRootItem
    {
        ItemTypeName TypeName { get; }
    }
}
