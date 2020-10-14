using TheToolsmiths.Ddl.Models.Compiled.Paths;

namespace TheToolsmiths.Ddl.Models.Compiled.Types.TypePaths.References
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
