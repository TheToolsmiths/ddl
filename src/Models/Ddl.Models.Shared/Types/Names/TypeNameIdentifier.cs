using TheToolsmiths.Ddl.Models.Paths;

namespace TheToolsmiths.Ddl.Models.Types.Names
{
    public abstract class TypeNameIdentifier
    {
        protected TypeNameIdentifier(string name)
        {
            this.Name = name;
        }

        public abstract PathPartKind IdentifierKind { get; }

        public string Name { get; }

        public abstract override string ToString();
    }
}
