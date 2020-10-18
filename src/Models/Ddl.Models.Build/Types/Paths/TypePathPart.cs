using TheToolsmiths.Ddl.Models.Paths;

namespace TheToolsmiths.Ddl.Models.Build.Types.Paths
{
    public abstract class TypePathPart : IPathPart
    {
        protected TypePathPart(string name)
        {
            this.Name = name;
        }

        public abstract PathPartKind PartKind { get; }

        public string Name { get; }
    }
}
