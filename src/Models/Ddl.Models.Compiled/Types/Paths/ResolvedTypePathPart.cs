using TheToolsmiths.Ddl.Models.Paths;

namespace TheToolsmiths.Ddl.Models.Compiled.Types.Paths
{
    public abstract class ResolvedTypePathPart : IPathPart
    {
        protected ResolvedTypePathPart(string name)
        {
            this.Name = name;
        }

        public abstract PathPartKind PartKind { get; }

        public string Name { get; }
    }
}
