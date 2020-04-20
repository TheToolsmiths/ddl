using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Models.FileContents;
using TheToolsmiths.Ddl.Parser.Models.Types;

namespace TheToolsmiths.Ddl.Parser.Models.Enums
{
    public class EnumStructDefinition : TypedRootContentItem
    {
        public EnumStructDefinition(
            ITypeName typeName,
            EnumStructDefinitionContent content,
            IReadOnlyList<IAttributeUse> attributes)
        : base(typeName, attributes)
        {
            this.Content = content;
        }

        public override FileContentItemType ItemType => FileContentItemType.StructDeclaration;

        public EnumStructDefinitionContent Content { get; }
    }
}
