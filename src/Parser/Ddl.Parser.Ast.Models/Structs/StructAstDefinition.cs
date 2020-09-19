using TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Ast.Models.EntryTypes;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Names;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Structs
{
    public class StructAstDefinition : AstTypedAttributableRootItem
    {
        public StructAstDefinition(
            TypeName typeName,
            StructDefinitionContent content,
            AstAttributeUseCollection attributes)
            : base(typeName, attributes)
        {
            this.Content = content;
        }

        public override AstItemType ItemType => CommonItemTypes.StructDeclaration;

        public StructDefinitionContent Content { get; }
    }
}
