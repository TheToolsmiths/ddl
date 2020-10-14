using TheToolsmiths.Ddl.Models.Ast.AttributeUsage;
using TheToolsmiths.Ddl.Models.Ast.ContentUnits.Items;
using TheToolsmiths.Ddl.Models.Ast.EntryTypes;
using TheToolsmiths.Ddl.Models.Ast.Types.Names;

namespace TheToolsmiths.Ddl.Models.Ast.Structs
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
