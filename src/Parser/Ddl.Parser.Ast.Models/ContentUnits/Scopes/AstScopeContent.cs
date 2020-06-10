using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes
{
    public class AstScopeContent
    {
        public AstScopeContent(IReadOnlyList<IAstRootItem> items, IReadOnlyList<IAstRootScope> scopes)
        {
            this.Items = items;
            this.Scopes = scopes;
        }

        public IReadOnlyList<IAstRootItem> Items { get; }

        public IReadOnlyList<IAstRootScope> Scopes { get; }
    }
}
