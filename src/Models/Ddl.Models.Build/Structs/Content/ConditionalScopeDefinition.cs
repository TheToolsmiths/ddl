using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.ConditionalExpressions;

namespace TheToolsmiths.Ddl.Models.Build.Structs.Content
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