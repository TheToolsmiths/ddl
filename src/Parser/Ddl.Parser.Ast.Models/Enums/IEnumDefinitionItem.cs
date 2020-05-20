using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Items;

namespace TheToolsmiths.Ddl.Parser.Models.Enums
{
    public interface IEnumDefinitionItem : ITypedContentSubItem
    {
        EnumDefinitionItemType ItemType { get; }
    }
}
