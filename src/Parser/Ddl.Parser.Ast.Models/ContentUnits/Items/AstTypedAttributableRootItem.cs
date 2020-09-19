using TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Names;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items
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
