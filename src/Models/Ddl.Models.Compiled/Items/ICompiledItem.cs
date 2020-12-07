using TheToolsmiths.Ddl.Models.EntryTypes;
using TheToolsmiths.Ddl.Models.ItemIds;

namespace TheToolsmiths.Ddl.Models.Compiled.Items
{
    public interface ICompiledItem
    {
        ItemId ItemId { get; }

        ItemType ItemType { get; }
    }
}
