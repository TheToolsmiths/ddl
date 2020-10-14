using TheToolsmiths.Ddl.Models.Ast.AttributeUsage;
using TheToolsmiths.Ddl.Models.Ast.Types.Names;

namespace TheToolsmiths.Ddl.Models.Ast.ContentUnits.Items
{
    public abstract class AstTypedAttributableRootItem : AstTypedRootItem, IAstTypedAttributableRootItem
    {
        protected AstTypedAttributableRootItem(TypeName typeName, AstAttributeUseCollection attributes)
        : base(typeName)
        {
            this.Attributes = attributes;
        }

        public AstAttributeUseCollection Attributes { get; }
    }
}
