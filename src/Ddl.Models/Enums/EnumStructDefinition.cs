using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.FileContents;
using TheToolsmiths.Ddl.Models.Types;

namespace TheToolsmiths.Ddl.Models.Enums
{
    public class EnumStructDefinition : IRootContentItem
    {
        public EnumStructDefinition(
            ITypeName typeName,
            EnumStructDefinitionContent content,
            IReadOnlyList<IAttributeUse> attributes)
        {
            this.TypeName = typeName;
            this.Content = content;
            this.Attributes = attributes;
        }

        public FileContentItemType ItemType => FileContentItemType.StructDeclaration;

        public IReadOnlyList<IAttributeUse> Attributes { get; }

        public ITypeName TypeName { get; }

        public EnumStructDefinitionContent Content { get; }
    }
}
