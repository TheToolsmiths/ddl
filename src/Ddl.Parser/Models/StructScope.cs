using TheToolsmiths.Ddl.Parser.Models.ConditionalExpressions;

namespace TheToolsmiths.Ddl.Parser.Models
{
    public class StructScope : IStructDefinitionItem
    {
        public StructScope(ConditionalExpression conditionalExpression, StructDefinitionContent structContent)
        {
            ConditionalExpression = conditionalExpression;
            StructContent = structContent;
        }

        public ConditionalExpression ConditionalExpression { get; }

        public StructDefinitionContent StructContent { get; }

        public StructDefinitionItemType ItemType => StructDefinitionItemType.Scope;
    }
}
