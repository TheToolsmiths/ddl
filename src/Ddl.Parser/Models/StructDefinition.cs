using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Parser.Models
{
    public class StructDefinition
    {
        public StructDefinition(
            TypeName typeName,
            StructDefinitionContent content,
            IReadOnlyList<IAttributeUse> attributes)
        {
            TypeName = typeName;
            Content = content;
            Attributes = attributes;
        }

        public IReadOnlyList<IAttributeUse> Attributes { get; }

        public TypeName TypeName { get; }

        public StructDefinitionContent Content { get; }
    }
}
