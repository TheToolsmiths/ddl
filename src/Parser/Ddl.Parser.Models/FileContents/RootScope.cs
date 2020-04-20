﻿using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models.ConditionalExpressions;

namespace TheToolsmiths.Ddl.Parser.Models.FileContents
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

        public override FileContentItemType ItemType => FileContentItemType.FileScope;

        public ConditionalExpression ConditionalExpression { get; }

        public IReadOnlyList<IRootContentItem> ContentItems { get; }
    }
}