using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.FileContents;
using TheToolsmiths.Ddl.Models.Types;

namespace TheToolsmiths.Ddl.Models.Structs
{
    public class StructDefinition : TypedRootContentItem
    {
        public StructDefinition(
            ITypeName typeName,
            StructDefinitionContent content,
            IReadOnlyList<IAttributeUse> attributes) 
            : base(typeName, attributes)
        {
            this.Content = content;
        }

        public override FileContentItemType ItemType => FileContentItemType.StructDeclaration;

        public StructDefinitionContent Content { get; }
    }
}
