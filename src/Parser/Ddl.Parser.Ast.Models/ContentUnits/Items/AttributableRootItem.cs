using System.Collections.Generic;

using TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Names;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items
{
    public abstract class AttributableRootItem : IAstAttributableRootItem
    {
        protected AttributableRootItem(TypeName typeName, IReadOnlyList<IAstAttributeUse> attributes)
        {
            this.TypeName = typeName;
            this.Attributes = attributes;
        }

        public abstract ContentUnitItemType ItemType { get; }

        public IReadOnlyList<IAstAttributeUse> Attributes { get; }

        public TypeName TypeName { get; }
    }
}
