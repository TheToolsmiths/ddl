using System;
using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Enums
{
    public class EnumStructAstDefinitionContent
    {
        public EnumStructAstDefinitionContent(IReadOnlyList<IEnumStructDefinitionItem> items)
        {
            this.Items = items;
        }

        public IReadOnlyList<IEnumStructDefinitionItem> Items { get; }

        public bool IsEmpty => this.Items.Count == 0;

        public static EnumStructAstDefinitionContent CreateEmpty()
        {
            return new EnumStructAstDefinitionContent(Array.Empty<IEnumStructDefinitionItem>());
        }
    }
}
