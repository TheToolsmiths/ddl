using TheToolsmiths.Ddl.Models.Compiled.Paths;

namespace TheToolsmiths.Ddl.Models.Compiled.ImportPaths
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
