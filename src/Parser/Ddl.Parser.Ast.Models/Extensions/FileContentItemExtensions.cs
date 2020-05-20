using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Models.Structs;

namespace TheToolsmiths.Ddl.Parser.Models
{
    public static class FileContentItemExtensions
    {
        public static bool HasAnyItemOfType(this IEnumerable<IRootItem> items, ContentUnitItemType itemType)
        {
            return items.Any(i => i.ItemType == itemType);
        }

        public static bool HasAnyStructDeclarations(this IEnumerable<IRootItem> items)
        {
            return items.HasAnyItemOfType(ContentUnitItemType.StructDeclaration);
        }

        public static IEnumerable<StructDefinition> GetAllStructDefinitions(this IEnumerable<IRootItem> items)
        {
            return items.OfType<StructDefinition>();
        }
    }
}
