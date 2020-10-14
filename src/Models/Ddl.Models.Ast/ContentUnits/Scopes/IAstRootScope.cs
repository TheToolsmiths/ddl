using TheToolsmiths.Ddl.Models.Ast.ContentUnits.Entries;
using TheToolsmiths.Ddl.Models.Ast.EntryTypes;

namespace TheToolsmiths.Ddl.Models.Ast.ContentUnits.Scopes
{
    public interface IAstRootScope : IAstRootEntry
    {
        AstScopeType ScopeType { get; }

        AstScopeContent Content { get; }
    }
}
