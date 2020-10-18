using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.ConditionalExpressions;

namespace TheToolsmiths.Ddl.Models.Build.Structs.Content
{
    public class ConditionalScope : Scope
    {
        public ConditionalScope(
            IReadOnlyList<IStructItem> items,
            ConditionalExpression conditionalExpression)
            : base(items)
        {
            this.ConditionalExpression = conditionalExpression;
        }

        public ConditionalExpression ConditionalExpression { get; }
    }
}
