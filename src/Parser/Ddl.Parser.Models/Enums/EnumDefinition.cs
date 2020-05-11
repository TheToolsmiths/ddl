using System.Collections.Generic;
using Ddl.Common.Models;
using TheToolsmiths.Ddl.Parser.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Models.Types;

namespace TheToolsmiths.Ddl.Parser.Models.Enums
{
    public class EnumDefinition : TypedAttributableRootContentItem
    {
        public EnumDefinition(
            ITypeName typeName,
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
