using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.ConditionalExpressions;

namespace TheToolsmiths.Ddl.Models.Compiled.Structs.Content
{
    public class ConditionalCompiledStructScope : CompiledStructScope
    {
        public ConditionalCompiledStructScope(
            IReadOnlyList<ICompiledStructItem> items,
            ConditionalExpression conditionalExpression)
            : base(items)
        {
            this.ConditionalExpression = conditionalExpression;
        }

        public ConditionalExpression ConditionalExpression { get; }
    }
}
