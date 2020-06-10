using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Names;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items
{
    public interface IAstTypedRootItem : IAstRootItem, ITypedContentItem
    {
        TypeName TypeName { get; }
    }
}
