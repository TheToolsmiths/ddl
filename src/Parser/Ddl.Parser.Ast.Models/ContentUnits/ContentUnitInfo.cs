using System.Diagnostics;
using System.IO;

namespace TheToolsmiths.Ddl.Parser.Models.ContentUnits
{
    [DebuggerDisplay("{" + nameof(RelativePath) + "}")]
    public class ContentUnitInfo
    {
        public ContentUnitInfo(string id, string name, string relativePath, FileInfo? file = null)
        {
            this.Name = name;
            this.RelativePath = relativePath;
            this.File = file;
            this.Id = id;
        }

        public string Id { get; }

        public string Name { get; }

        public string RelativePath { get; }

        public FileInfo? File { get; }


        public override string ToString()
        {
            return this.Name;
        }
    }
}
