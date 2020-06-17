namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes
{
    public class AstFileRootScope : AstRootScope, IAstFileRootScope
    {
        public AstFileRootScope(AstScopeContent content)
            : base(content)
        {
        }

        public override AstContentUnitScopeType ScopeType => AstContentUnitScopeType.FileScope;
    }
}
