using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.FileContents;
using TheToolsmiths.Ddl.Models.Types;

namespace TheToolsmiths.Ddl.Models.Structs
{
    public class StructDefinition : IRootContentItem
    {
        public StructDefinition(
            ITypeName typeName,
            StructDefinitionContent content,
            IReadOnlyList<IAttributeUse> attributes)
        {
            this.TypeName = typeName;
            this.Content = content;
            this.Attributes = attributes;
        }

        public FileContentItemType ItemType => FileContentItemType.StructDeclaration;

        public IReadOnlyList<IAttributeUse> Attributes { get; }

        public ITypeName TypeName { get; }

        public StructDefinitionContent Content { get; }
    }
}
