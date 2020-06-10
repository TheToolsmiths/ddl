using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Ast.Models.Structs;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Extensions
{
    public static class FileContentItemExtensions
    {
        public static bool HasAnyItemOfType(this IEnumerable<IAstRootItem> items, ContentUnitItemType itemType)
        {
            return items.Any(i => i.ItemType == itemType);
        }

        public static bool HasAnyStructDeclarations(this IEnumerable<IAstRootItem> items)
        {
            return items.HasAnyItemOfType(ContentUnitItemType.StructDeclaration);
        }

        public static IEnumerable<StructAstDefinition> GetAllStructDefinitions(this IEnumerable<IAstRootItem> items)
        {
            return items.OfType<StructAstDefinition>();
        }
    }
}
