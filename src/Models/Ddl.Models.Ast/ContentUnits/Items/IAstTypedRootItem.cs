using TheToolsmiths.Ddl.Models.Ast.Types.Names;

namespace TheToolsmiths.Ddl.Models.Ast.ContentUnits.Items
{
    public interface IAstTypedRootItem : IAstRootItem
    {
        TypeName TypeName { get; }
    }
}
