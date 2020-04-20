using System;
using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Parser.Models.FileContents
{
    public class FileContent
    {
        public FileContent(
            IReadOnlyList<IRootContentItem> items)
        {
            this.Items = items;
        }

        public IReadOnlyList<IRootContentItem> Items { get; }

        public static FileContent CreateEmpty()
        {
            return new FileContent(Array.Empty<IRootContentItem>());
        }
    }
}
