using TheToolsmiths.Ddl.Models.Paths;

namespace TheToolsmiths.Ddl.Models.Types.TypePaths.References
{
    public abstract class TypeReferencePathPart : IPathPart
    {
        protected TypeReferencePathPart(string name)
        {
            this.Name = name;
        }

        public abstract PathPartKind PartKind { get; }

        public string Name { get; }
    }
}
