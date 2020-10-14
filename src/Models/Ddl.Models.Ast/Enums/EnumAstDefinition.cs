using TheToolsmiths.Ddl.Models.Ast.AttributeUsage;
using TheToolsmiths.Ddl.Models.Ast.ContentUnits.Items;
using TheToolsmiths.Ddl.Models.Ast.EntryTypes;
using TheToolsmiths.Ddl.Models.Ast.Types.Names;

namespace TheToolsmiths.Ddl.Models.Ast.Enums
{
    public class EnumAstDefinition : AstTypedAttributableRootItem
    {
        public EnumAstDefinition(
            TypeName typeName,
            EnumDefinitionContent content,
            AstAttributeUseCollection attributes)
            : base(typeName, attributes)
        {
            this.Content = content;
        }

        public override AstItemType ItemType => CommonItemTypes.EnumDeclaration;

        public EnumDefinitionContent Content { get; }
    }
}
