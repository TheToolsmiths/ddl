using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Models.Compiled.Structs.Content
{
    public class StructDefinitionContent
    {
        public StructDefinitionContent(IReadOnlyList<IStructDefinitionItem> items)
        {
            this.Items = items;
        }

        public IReadOnlyList<IStructDefinitionItem> Items { get; }
    }
}
