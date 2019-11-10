using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Parser.Models
{
    public class FileContents
    {
        public FileContents(IReadOnlyList<StructDefinition> structDefinitions)
        {
            StructDefinitions = new List<StructDefinition>(structDefinitions);
        }

        public IReadOnlyList<StructDefinition> StructDefinitions { get; }
    }
}