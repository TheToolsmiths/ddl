using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;

namespace TheToolsmiths.Ddl.Parser.Parsers
{
    public class ScopeContentParseContext
    {
        public List<IRootItem> Items { get; } = new List<IRootItem>();

        public List<IRootScope> Scopes { get; } = new List<IRootScope>();

        public ScopeContent CreateScopeContent()
        {
            return new ScopeContent(this.Items, this.Scopes);
        }
    }
}
