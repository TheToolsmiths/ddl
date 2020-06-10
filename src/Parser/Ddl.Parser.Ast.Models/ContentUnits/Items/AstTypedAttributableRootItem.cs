using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Names;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items
{
    public abstract class AstTypedAttributableRootItem : AstTypedRootItem, IAstTypedAttributableRootItem
    {
        protected AstTypedAttributableRootItem(TypeName typeName, IReadOnlyList<IAstAttributeUse> attributes)
        : base(typeName)
        {
            this.Attributes = attributes;
        }

        public IReadOnlyList<IAstAttributeUse> Attributes { get; }
    }
}
