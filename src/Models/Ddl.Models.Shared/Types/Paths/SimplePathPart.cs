using TheToolsmiths.Ddl.Models.Paths;

namespace TheToolsmiths.Ddl.Models.Types.Paths
{
    public class SimplePathPart : TypePathPart
    {
        public SimplePathPart(string name)
            : base(name)
        {
        }

        public override PathPartKind PartKind => PathPartKind.Simple;

        public override string ToString()
        {
            return this.Name;
        }
    }
}
