namespace TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes
{
    public class AstFileRootScope : IAstFileRootScope
    {
        public AstFileRootScope(AstScopeContent content)
        {
            this.Content = content;
        }

        public AstScopeContent Content { get; }
    }
}
