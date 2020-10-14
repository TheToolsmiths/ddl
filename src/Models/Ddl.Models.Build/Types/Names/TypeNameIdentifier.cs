using TheToolsmiths.Ddl.Models.Build.Paths;

namespace TheToolsmiths.Ddl.Models.Build.Types.Names
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
