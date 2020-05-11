using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Models.Structs;

namespace TheToolsmiths.Ddl.Parser.Models
{
    public static class FileContentItemExtensions
    {
        public static bool HasAnyItemOfType(this IReadOnlyList<IRootContentItem> items, ContentUnitItemType itemType)
        {
            return items.Any(i => i.ItemType == itemType);
        }

        public static bool HasAnyStructDeclarations(this IReadOnlyList<IRootContentItem> items)
        {
            return items.HasAnyItemOfType(ContentUnitItemType.StructDeclaration);
        }

        public static IEnumerable<StructDefinition> GetAllStructDefinitions(this IReadOnlyList<IRootContentItem> items)
        {
            return items.OfType<StructDefinition>();
        }
    }
}
