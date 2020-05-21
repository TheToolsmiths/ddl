using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Enums
{
    public interface IEnumDefinitionItem : ITypedContentSubItem
    {
        EnumDefinitionItemType ItemType { get; }
    }
}
