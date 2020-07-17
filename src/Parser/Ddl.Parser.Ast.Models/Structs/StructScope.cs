using TheToolsmiths.Ddl.Parser.Ast.Models.ConditionalExpressions;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Structs
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
