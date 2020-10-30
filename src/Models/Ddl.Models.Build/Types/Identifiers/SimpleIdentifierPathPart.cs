using TheToolsmiths.Ddl.Models.Paths;

namespace TheToolsmiths.Ddl.Models.Build.Types.Identifiers
{
    public class SimpleIdentifierPathPart : TypeIdentifierPathPart
    {
        public SimpleIdentifierPathPart(string name)
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
