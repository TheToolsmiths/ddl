using System.Collections.Generic;

using TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Names;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items
{
    public abstract class AttributableRootItem : IAttributableRootItem
    {
        protected AttributableRootItem(TypeName typeName, IReadOnlyList<IAttributeUse> attributes)
        {
            this.TypeName = typeName;
            this.Attributes = attributes;
        }

        public abstract ContentUnitItemType ItemType { get; }

        public IReadOnlyList<IAttributeUse> Attributes { get; }

        public TypeName TypeName { get; }
    }
}
