using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Models.FileContents;
using TheToolsmiths.Ddl.Parser.Models.Types;

namespace TheToolsmiths.Ddl.Parser.Models.Structs
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
