using System;
using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Parser.Models
{
    public class StructDefinitionContent
    {
        public StructDefinitionContent(IReadOnlyList<IStructDefinitionItem> items)
        {
            Items = items;
        }

        public IReadOnlyList<IStructDefinitionItem> Items { get; }

        public bool IsEmpty => Items.Count == 0;

        public static StructDefinitionContent CreateEmpty()
        {
            return new StructDefinitionContent(Array.Empty<IStructDefinitionItem>());
        }
    }
}
