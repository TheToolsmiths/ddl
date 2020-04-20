using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TheToolsmiths.Ddl.Parser.Models.ContentUnits
{
    [DebuggerDisplay("{" + nameof(Info) + "}")]
    public class ContentUnit
    {
        public ContentUnit(
            ContentUnitInfo info,
            IReadOnlyList<IRootContentItem> items)
        {
            this.Info = info;
            this.Items = items;
        }

        public ContentUnitInfo Info { get; }

        public IReadOnlyList<IRootContentItem> Items { get; }

        public static ContentUnit CreateEmpty(ContentUnitInfo info)
        {
            return new ContentUnit(info, Array.Empty<IRootContentItem>());
        }
    }
}
