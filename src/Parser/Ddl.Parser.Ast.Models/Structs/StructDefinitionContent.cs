using System;
using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Structs
{
    public class StructDefinitionContent
    {
        public StructDefinitionContent(IReadOnlyList<IStructDefinitionItem> items)
        {
            this.Items = items;
        }

        public IReadOnlyList<IStructDefinitionItem> Items { get; }

        public bool IsEmpty => this.Items.Count == 0;

        public static StructDefinitionContent CreateEmpty()
        {
            return new StructDefinitionContent(Array.Empty<IStructDefinitionItem>());
        }
    }
}
