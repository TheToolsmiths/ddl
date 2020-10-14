using TheToolsmiths.Ddl.Models.Ast.AttributeUsage;

namespace TheToolsmiths.Ddl.Models.Ast.ContentUnits.Items
{
    public interface IAstAttributableRootItem : IAstRootItem
    {
        AstAttributeUseCollection Attributes { get; }
    }
}
