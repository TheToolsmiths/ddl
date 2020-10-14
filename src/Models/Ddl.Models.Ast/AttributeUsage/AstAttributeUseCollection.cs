using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Models.Ast.AttributeUsage
{
    public class AstAttributeUseCollection
    {
        private AstAttributeUseCollection(IReadOnlyList<IAstAttributeUse> items)
        {
            this.Items = items;
        }

        public static AstAttributeUseCollection Empty { get; } = Create(new List<IAstAttributeUse>());

        public bool HasAttributes => this.Items.Count > 0;

        public IReadOnlyList<IAstAttributeUse> Items { get; }

        public static AstAttributeUseCollection Create(IReadOnlyList<IAstAttributeUse> astAttributes)
        {
            return new AstAttributeUseCollection(astAttributes);
        }
    }
}
