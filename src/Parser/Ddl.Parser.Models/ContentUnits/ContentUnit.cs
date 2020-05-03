using System;
using System.Collections.Generic;
using System.Diagnostics;
using Ddl.Common.Models;

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
            this.Id = ContentUnitId.CreateNew();
        }

        public ContentUnitId Id { get; }

        public ContentUnitInfo Info { get; }

        public IReadOnlyList<IRootContentItem> Items { get; }

        public static ContentUnit CreateEmpty(ContentUnitInfo info)
        {
            return new ContentUnit(info, Array.Empty<IRootContentItem>());
        }
    }
}
