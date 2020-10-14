using TheToolsmiths.Ddl.Models.Ast.AttributeUsage;
using TheToolsmiths.Ddl.Models.Ast.EntryTypes;
using TheToolsmiths.Ddl.Models.Ast.Types.Names;

namespace TheToolsmiths.Ddl.Models.Ast.ContentUnits.Items
{
    public abstract class AttributableRootItem : IAstAttributableRootItem
    {
        protected AttributableRootItem(TypeName typeName, AstAttributeUseCollection attributes)
        {
            this.TypeName = typeName;
            this.Attributes = attributes;
        }

        public abstract AstItemType ItemType { get; }

        public AstAttributeUseCollection Attributes { get; }

        public TypeName TypeName { get; }
    }
}
