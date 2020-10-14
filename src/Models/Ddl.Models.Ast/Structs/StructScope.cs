using TheToolsmiths.Ddl.Models.Ast.ConditionalExpressions;

namespace TheToolsmiths.Ddl.Models.Ast.Structs
{
    public class StructScope : IStructDefinitionItem
    {
        public StructScope(AstConditionalExpression conditionalExpression, StructDefinitionContent content)
        {
            this.ConditionalExpression = conditionalExpression;
            this.Content = content;
        }

        public AstConditionalExpression ConditionalExpression { get; }

        public StructDefinitionContent Content { get; }

        public StructDefinitionItemType ItemType => StructDefinitionItemType.Scope;
    }
}
