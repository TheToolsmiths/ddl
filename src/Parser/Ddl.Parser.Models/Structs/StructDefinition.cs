using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Models.Types;

namespace TheToolsmiths.Ddl.Parser.Models.Structs
{
    public class StructDefinition : TypedAttributableRootContentItem
    {
        public StructDefinition(
            ITypeName typeName,
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
