using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Models
{
    public class FileContents
    {
        public FileContents(
            IReadOnlyList<FileScope> fileScopes,
            IReadOnlyList<StructDefinition> structDefinitions)
        {
            FileScopes = fileScopes;
            StructDefinitions = structDefinitions;
        }

        public IReadOnlyList<FileScope> FileScopes { get; }

        public IReadOnlyList<StructDefinition> StructDefinitions { get; }

        public static FileContents CreateEmpty()
        {
            return new FileContents(new List<FileScope>(), new List<StructDefinition>());
        }
    }
}
