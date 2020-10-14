namespace TheToolsmiths.Ddl.Models.Ast.ContentUnits.Scopes
{
    public class AstContentUnitScope
    {
        public AstContentUnitScope(AstScopeContent content)
        {
            this.Content = content;
        }

        public AstScopeContent Content { get; }
    }
}
