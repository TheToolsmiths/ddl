using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Models.Structs;

namespace TheToolsmiths.Ddl.Models
{
    public static class StructDefinitionItemExtensions
    {
        public static bool HasAnyItemOfType(this StructDefinitionContent content, StructDefinitionItemType itemType)
        {
            return content.Items.Any(i => i.ItemType == itemType);
        }

        public static bool HasAnyFieldDefinitions(this StructDefinitionContent content)
        {
            return content.HasAnyItemOfType(StructDefinitionItemType.FieldDefinition);
        }

        public static bool HasAnyScopes(this StructDefinitionContent content)
        {
            return content.HasAnyItemOfType(StructDefinitionItemType.Scope);
        }

        public static IEnumerable<FieldDefinition> GetAllFields(this StructDefinitionContent content)
        {
            return content.Items.OfType<FieldDefinition>();
        }

        public static IEnumerable<StructScope> GetAllScopes(this StructDefinitionContent content)
        {
            return content.Items.OfType<StructScope>();
        }
    }
}
