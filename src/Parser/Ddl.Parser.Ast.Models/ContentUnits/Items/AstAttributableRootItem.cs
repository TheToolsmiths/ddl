using TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items
{
    public abstract class AstAttributableRootItem : AstRootItem, IAstAttributableRootItem
    {
        protected AstAttributableRootItem(AstAttributeUseCollection attributes)
        {
            this.Attributes = attributes;
        }

        public AstAttributeUseCollection Attributes { get; }
    }
}
