using System;
using System.Collections.Generic;

namespace TheToolsmiths.Ddl.Models.FileContents
{
    public class FileContent
    {
        public FileContent(
            IReadOnlyList<IFileContentItem> items)
        {
            this.Items = items;
        }

        public IReadOnlyList<IFileContentItem> Items { get; }

        public static FileContent CreateEmpty()
        {
            return new FileContent(Array.Empty<IFileContentItem>());
        }
    }
}
