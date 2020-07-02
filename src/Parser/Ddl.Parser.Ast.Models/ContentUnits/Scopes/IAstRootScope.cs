using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Entries;
using TheToolsmiths.Ddl.Parser.Ast.Models.EntryTypes;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes
{
    public interface IAstRootScope : IAstRootEntry
    {
        AstScopeType ScopeType { get; }

        AstScopeContent Content { get; }
    }
}
