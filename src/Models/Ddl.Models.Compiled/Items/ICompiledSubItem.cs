using TheToolsmiths.Ddl.Models.EntryTypes;
using TheToolsmiths.Ddl.Models.Items;

namespace TheToolsmiths.Ddl.Models.Compiled.Items
{
    public interface ICompiledSubItem
    {
        SubItemId SubItemId { get; }

        SubItemType SubItemType { get; }
    }
}
