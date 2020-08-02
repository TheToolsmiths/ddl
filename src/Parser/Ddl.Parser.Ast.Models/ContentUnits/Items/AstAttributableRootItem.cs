using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items
{
    public abstract class AstAttributableRootItem : AstRootItem, IAstAttributableRootItem
    {
        protected AstAttributableRootItem(IReadOnlyList<IAstAttributeUse> attributes)
        {
            this.Attributes = attributes;
        }

        public IReadOnlyList<IAstAttributeUse> Attributes { get; }
    }
}
