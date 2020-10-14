using TheToolsmiths.Ddl.Models.Compiled.Paths;

namespace TheToolsmiths.Ddl.Models.Compiled.Types.TypePaths.Identifiers
{
    public abstract class TypeIdentifierPathPart : IPathPart
    {
        protected TypeIdentifierPathPart(string name)
        {
            this.Name = name;
        }

        public abstract PathPartKind PartKind { get; }

        public string Name { get; }
    }
}
