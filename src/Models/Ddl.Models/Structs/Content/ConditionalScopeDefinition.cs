using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.ConditionalExpressions;

namespace TheToolsmiths.Ddl.Models.Structs.Content
{
    public class ConditionalScopeDefinition : ScopeDefinition
    {
        public ConditionalScopeDefinition(
            IReadOnlyList<IStructDefinitionItem> items,
            ConditionalExpression conditionalExpression)
            : base(items)
        {
            this.ConditionalExpression = conditionalExpression;
        }

        public ConditionalExpression ConditionalExpression { get; }
    }
}