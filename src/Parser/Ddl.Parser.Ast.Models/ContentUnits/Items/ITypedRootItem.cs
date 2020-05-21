using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Names;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items
{
    public interface ITypedRootItem : IRootItem, ITypedContentItem
    {
        ITypeName TypeName { get; }
    }
}
