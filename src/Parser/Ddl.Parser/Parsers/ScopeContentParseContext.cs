using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;

namespace TheToolsmiths.Ddl.Parser.Parsers
{
    public class ScopeContentParseContext
    {
        public List<IAstRootItem> Items { get; } = new List<IAstRootItem>();

        public List<IAstRootScope> Scopes { get; } = new List<IAstRootScope>();

        public AstScopeContent CreateScopeContent()
        {
            return new AstScopeContent(this.Items, this.Scopes);
        }
    }
}
