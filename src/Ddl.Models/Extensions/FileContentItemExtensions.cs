using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Models.FileContents;
using TheToolsmiths.Ddl.Models.Structs;

namespace TheToolsmiths.Ddl.Models
{
    public static class FileContentItemExtensions
    {
        public static bool HasAnyItemOfType(this FileContent content, FileContentItemType itemType)
        {
            return content.Items.Any(i => i.ItemType == itemType);
        }

        public static bool HasAnyStructDeclarations(this FileContent content)
        {
            return content.HasAnyItemOfType(FileContentItemType.StructDeclaration);
        }

        public static bool HasAnyScopes(this FileContent content)
        {
            return content.HasAnyItemOfType(FileContentItemType.FileScope);
        }

        public static IEnumerable<StructDefinition> GetAllStructDefinitions(this FileContent content)
        {
            return content.Items.OfType<StructDefinition>();
        }

        public static IEnumerable<FileScope> GetAllScopes(this FileContent content)
        {
            return content.Items.OfType<FileScope>();
        }
    }
}
