using System.Diagnostics.CodeAnalysis;
using TheToolsmiths.Ddl.Models.Compiled.Items.References;
using TheToolsmiths.Ddl.Models.ItemIds;

namespace TheToolsmiths.Ddl.Writer
{
    public interface IEntityKeyMap
    {
        bool TryGetItemKey(in ItemId itemId, [MaybeNullWhen(false)] out string itemKey);

        bool TryGetSubItemKey(in ItemId itemId, in SubItemId subItemId, [MaybeNullWhen(false)] out string subItemKey);

        bool TryGetItemKey(ItemReference itemReference, [MaybeNullWhen(false)] out string itemKey);

        bool TryGetItemKey(SubItemReference subItemReference, [MaybeNullWhen(false)] out string itemKey, [MaybeNullWhen(false)] out string subItemKey);
    }
}
