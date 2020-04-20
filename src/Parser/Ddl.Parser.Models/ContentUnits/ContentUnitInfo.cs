using System.Diagnostics;
using System.IO;

namespace TheToolsmiths.Ddl.Parser.Models.ContentUnits
{
    [DebuggerDisplay("{" + nameof(Name) + "}")]
    public class ContentUnitInfo
    {
        public ContentUnitInfo(string id, string name, FileInfo? file = null)
        {
            this.Name = name;
            this.File = file;
            this.Id = id;
        }

        public string Name { get; }

        public FileInfo? File { get; }

        public string Id { get; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
