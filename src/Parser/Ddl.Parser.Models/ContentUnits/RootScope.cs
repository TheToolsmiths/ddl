using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models.ConditionalExpressions;

namespace TheToolsmiths.Ddl.Parser.Models.ContentUnits
{
    public class RootScope : RootContentItem
    {
        public RootScope(
            ConditionalExpression conditionalExpression,
            IReadOnlyList<IRootContentItem> contentItems)
        {
            this.ConditionalExpression = conditionalExpression;
            this.ContentItems = contentItems;
        }

        public override ContentUnitItemType ItemType => ContentUnitItemType.RootScope;

        public ConditionalExpression ConditionalExpression { get; }

        public IReadOnlyList<IRootContentItem> ContentItems { get; }
    }
}
