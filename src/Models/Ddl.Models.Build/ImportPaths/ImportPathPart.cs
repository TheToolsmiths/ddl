using TheToolsmiths.Ddl.Models.Paths;

namespace TheToolsmiths.Ddl.Models.Build.ImportPaths
{
    public class ImportPathPart : IPathPart
    {
        public ImportPathPart(string name)
        {
            this.Name = name;
        }

        public PathPartKind PartKind => PathPartKind.Simple;

        public string Name { get; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
