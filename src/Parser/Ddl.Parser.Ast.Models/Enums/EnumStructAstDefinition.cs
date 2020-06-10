using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Names;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Enums
{
    public class EnumStructAstDefinition : AstTypedAttributableRootItem
    {
        public EnumStructAstDefinition(
            TypeName typeName,
            EnumStructAstDefinitionContent content,
            IReadOnlyList<IAstAttributeUse> attributes)
        : base(typeName, attributes)
        {
            this.Content = content;
        }

        public override ContentUnitItemType ItemType => ContentUnitItemType.EnumStructDeclaration;

        public EnumStructAstDefinitionContent Content { get; }
    }
}
