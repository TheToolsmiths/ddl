using TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Ast.Models.EntryTypes;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Names;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items
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
