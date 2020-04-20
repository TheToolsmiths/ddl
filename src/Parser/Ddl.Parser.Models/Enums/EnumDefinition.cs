using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits;
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
            this.Content = content;
        }

        public override ContentUnitItemType ItemType => ContentUnitItemType.StructDeclaration;

        public EnumDefinitionContent Content { get; }
    }
}
