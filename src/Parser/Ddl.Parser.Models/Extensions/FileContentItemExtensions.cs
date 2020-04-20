using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Parser.Models.FileContents;
using TheToolsmiths.Ddl.Parser.Models.Structs;

namespace TheToolsmiths.Ddl.Parser.Models
{
    public static class FileContentItemExtensions
    {
        public static bool HasAnyItemOfType(this IReadOnlyList<IRootContentItem> items, FileContentItemType itemType)
        {
            return items.Any(i => i.ItemType == itemType);
        }

        public static bool HasAnyStructDeclarations(this IReadOnlyList<IRootContentItem> items)
        {
            return items.HasAnyItemOfType(FileContentItemType.StructDeclaration);
        }

        public static bool HasAnyScopes(this IReadOnlyList<IRootContentItem> items)
        {
            return items.HasAnyItemOfType(FileContentItemType.FileScope);
        }

        public static IEnumerable<StructDefinition> GetAllStructDefinitions(this IReadOnlyList<IRootContentItem> items)
        {
            return items.OfType<StructDefinition>();
        }

        public static IEnumerable<RootScope> GetAllScopes(this IReadOnlyList<IRootContentItem> items)
        {
            return items.OfType<RootScope>();
        }
    }
}
