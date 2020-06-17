using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Entries;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes
{
    public interface IAstRootScope : IAstRootEntry
    {
        AstContentUnitScopeType ScopeType { get; }

        AstScopeContent Content { get; }
    }
}
