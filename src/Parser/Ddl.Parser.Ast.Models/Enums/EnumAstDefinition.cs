using TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Ast.Models.EntryTypes;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Names;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Enums
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
