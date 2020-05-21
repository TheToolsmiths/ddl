using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Names;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items
{
    public abstract class TypedAttributableRootItem : TypedRootItem, ITypedAttributableRootItem
    {
        protected TypedAttributableRootItem(ITypeName typeName, IReadOnlyList<IAttributeUse> attributes)
        : base(typeName)
        {
            this.Attributes = attributes;
        }

        public IReadOnlyList<IAttributeUse> Attributes { get; }
    }
}
