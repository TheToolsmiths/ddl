using System.Collections.Generic;
using Ddl.Common.Models;
using TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Names;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Enums
{
    public class EnumDefinition : TypedAttributableRootItem
    {
        public EnumDefinition(
            TypeName typeName,
            EnumDefinitionContent content,
            IReadOnlyList<IAttributeUse> attributes)
            : base(typeName, attributes)
        {
            this.ItemId = ContentUnitItemId.CreateNew();
            this.Content = content;
        }

        public override ContentUnitItemType ItemType => ContentUnitItemType.EnumDeclaration;

        public EnumDefinitionContent Content { get; }
        
        public ContentUnitItemId ItemId { get; }
    }
}
