using TheToolsmiths.Ddl.Models.Paths;

namespace TheToolsmiths.Ddl.Models.Build.Types.Identifiers
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
