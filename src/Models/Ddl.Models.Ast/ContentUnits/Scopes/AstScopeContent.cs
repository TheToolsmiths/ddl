using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Ast.ContentUnits.Items;

namespace TheToolsmiths.Ddl.Models.Ast.ContentUnits.Scopes
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
