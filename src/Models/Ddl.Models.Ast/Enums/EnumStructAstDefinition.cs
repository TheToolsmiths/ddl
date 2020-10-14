using TheToolsmiths.Ddl.Models.Ast.AttributeUsage;
using TheToolsmiths.Ddl.Models.Ast.ContentUnits.Items;
using TheToolsmiths.Ddl.Models.Ast.EntryTypes;
using TheToolsmiths.Ddl.Models.Ast.Types.Names;

namespace TheToolsmiths.Ddl.Models.Ast.Enums
{
    public class EnumStructAstDefinition : AstTypedAttributableRootItem
    {
        public EnumStructAstDefinition(
            TypeName typeName,
            EnumStructAstDefinitionContent content,
            AstAttributeUseCollection attributes)
        : base(typeName, attributes)
        {
            this.Content = content;
        }

        public override AstItemType ItemType => CommonItemTypes.EnumStructDeclaration;

        public EnumStructAstDefinitionContent Content { get; }
    }
}
