using TheToolsmiths.Ddl.Models.EntryTypes;
using TheToolsmiths.Ddl.Models.Items;

namespace TheToolsmiths.Ddl.Models.Compiled.Items
{
    public interface ICompiledItem
    {
        ItemId ItemId { get; }

        ItemType ItemType { get; }
    }
}
