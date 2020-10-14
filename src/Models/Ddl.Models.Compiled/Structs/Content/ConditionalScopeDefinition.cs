using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Compiled.ConditionalExpressions;

namespace TheToolsmiths.Ddl.Models.Compiled.Structs.Content
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