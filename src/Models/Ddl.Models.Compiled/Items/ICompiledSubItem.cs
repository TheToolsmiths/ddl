using TheToolsmiths.Ddl.Models.EntryTypes;
using TheToolsmiths.Ddl.Models.ItemIds;

namespace TheToolsmiths.Ddl.Models.Compiled.Items
{
    public interface ICompiledSubItem
    {
        SubItemId SubItemId { get; }

        SubItemType SubItemType { get; }
    }
}
