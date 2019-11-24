using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Parser.Models
{
    public class StructDefinitionContent
    {
        public StructDefinitionContent(IReadOnlyList<FieldDefinition> fields, IReadOnlyList<StructScope> scopes)
        {
            Fields = fields;
            Scopes = scopes;
        }

        public IReadOnlyList<FieldDefinition> Fields { get; }

        public IReadOnlyList<StructScope> Scopes { get; }

        public bool IsEmpty => Fields.Count == 0 && Scopes.Count == 0;

        public static StructDefinitionContent CreateEmpty()
        {
            return new StructDefinitionContent(
                new List<FieldDefinition>(),
                new List<StructScope>());
        }
    }
}
