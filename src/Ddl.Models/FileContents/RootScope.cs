using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.ConditionalExpressions;

namespace TheToolsmiths.Ddl.Models.FileContents
{
    public class RootScope : IRootContentItem
    {
        public RootScope(
            ConditionalExpression conditionalExpression,
            IReadOnlyList<IRootContentItem> contentItems)
        {
            this.ConditionalExpression = conditionalExpression;
            this.ContentItems = contentItems;
        }

        public FileContentItemType ItemType => FileContentItemType.FileScope;

        public ConditionalExpression ConditionalExpression { get; }

        public IReadOnlyList<IRootContentItem> ContentItems { get; }
    }
}
