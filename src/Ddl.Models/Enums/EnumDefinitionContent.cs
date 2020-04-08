using System;
using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Models.Enums
{
    public class EnumDefinitionContent
    {
        public EnumDefinitionContent(IReadOnlyList<IEnumDefinitionItem> items)
        {
            this.Items = items;
        }

        public IReadOnlyList<IEnumDefinitionItem> Items { get; }

        public bool IsEmpty => this.Items.Count == 0;

        public static EnumDefinitionContent CreateEmpty()
        {
            return new EnumDefinitionContent(Array.Empty<IEnumDefinitionItem>());
        }
    }
}