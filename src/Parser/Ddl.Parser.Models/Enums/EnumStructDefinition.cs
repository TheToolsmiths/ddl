using System.Collections.Generic;
using Ddl.Common.Models;
using TheToolsmiths.Ddl.Parser.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Models.Types;
using TheToolsmiths.Ddl.Parser.Models.Types.Names;

namespace TheToolsmiths.Ddl.Parser.Models.Enums
{
    public class EnumStructDefinition : TypedAttributableRootItem
    {
        public EnumStructDefinition(
            ITypeName typeName,
            EnumStructDefinitionContent content,
            IReadOnlyList<IAttributeUse> attributes)
        : base(typeName, attributes)
        {
            this.Content = content;
        }

        public override ContentUnitItemType ItemType => ContentUnitItemType.EnumStructDeclaration;

        public EnumStructDefinitionContent Content { get; }
        
        public ContentUnitItemId ItemId { get; }
    }
}
