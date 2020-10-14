using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Models.Ast.ContentUnits.Items;
using TheToolsmiths.Ddl.Models.Ast.EntryTypes;
using TheToolsmiths.Ddl.Models.Ast.Structs;

namespace TheToolsmiths.Ddl.Models.Ast
{
    public static class FileContentItemExtensions
    {
        public static bool HasAnyItemOfType(this IEnumerable<IAstRootItem> items, AstItemType itemType)
        {
            return items.Any(i => i.ItemType == itemType);
        }

        public static bool HasAnyStructDeclarations(this IEnumerable<IAstRootItem> items)
        {
            return items.HasAnyItemOfType(CommonItemTypes.StructDeclaration);
        }

        public static IEnumerable<StructAstDefinition> GetAllStructDefinitions(this IEnumerable<IAstRootItem> items)
        {
            return items.OfType<StructAstDefinition>();
        }
    }
}
