using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Names;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Structs
{
    public class StructDefinition : TypedAttributableRootItem
    {
        public StructDefinition(
            TypeName typeName,
            StructDefinitionContent content,
            IReadOnlyList<IAttributeUse> attributes) 
            : base(typeName, attributes)
        {
            this.Content = content;
        }

        public override ContentUnitItemType ItemType => ContentUnitItemType.StructDeclaration;

        public StructDefinitionContent Content { get; }
    }
}
