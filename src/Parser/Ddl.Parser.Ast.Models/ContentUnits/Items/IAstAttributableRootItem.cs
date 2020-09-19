using TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items
{
    public interface IAstAttributableRootItem : IAstRootItem
    {
        AstAttributeUseCollection Attributes { get; }
    }
}
