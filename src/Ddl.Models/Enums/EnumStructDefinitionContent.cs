using System;
using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Models.Enums
{
    public class EnumStructDefinitionContent
    {
        public EnumStructDefinitionContent(IReadOnlyList<IEnumStructDefinitionItem> items)
        {
            this.Items = items;
        }

        public IReadOnlyList<IEnumStructDefinitionItem> Items { get; }

        public bool IsEmpty => this.Items.Count == 0;

        public static EnumStructDefinitionContent CreateEmpty()
        {
            return new EnumStructDefinitionContent(Array.Empty<IEnumStructDefinitionItem>());
        }
    }
}
