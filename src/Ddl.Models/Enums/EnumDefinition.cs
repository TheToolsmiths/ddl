using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.FileContents;
using TheToolsmiths.Ddl.Models.Types;

namespace TheToolsmiths.Ddl.Models.Enums
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

        public override FileContentItemType ItemType => FileContentItemType.StructDeclaration;

        public EnumDefinitionContent Content { get; }
    }
}
