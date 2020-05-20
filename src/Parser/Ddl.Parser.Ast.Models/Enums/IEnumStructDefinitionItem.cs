using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Items;

namespace TheToolsmiths.Ddl.Parser.Models.Enums
{
    public interface IEnumStructDefinitionItem : ITypedContentSubItem
    {
        EnumStructDefinitionItemType ItemType { get; }
    }
}
