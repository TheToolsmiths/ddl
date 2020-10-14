using TheToolsmiths.Ddl.Models.Build.Paths;

namespace TheToolsmiths.Ddl.Models.Build.Types.TypePaths.Identifiers
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
