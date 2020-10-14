using TheToolsmiths.Ddl.Models.Build.Paths;

namespace TheToolsmiths.Ddl.Models.Build.Types.TypePaths.References
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
