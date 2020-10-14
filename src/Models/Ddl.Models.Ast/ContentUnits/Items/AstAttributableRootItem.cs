using TheToolsmiths.Ddl.Models.Ast.AttributeUsage;

namespace TheToolsmiths.Ddl.Models.Ast.ContentUnits.Items
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
