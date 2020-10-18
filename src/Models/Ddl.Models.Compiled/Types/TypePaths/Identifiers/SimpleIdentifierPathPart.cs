using TheToolsmiths.Ddl.Models.Paths;

namespace TheToolsmiths.Ddl.Models.Compiled.Types.TypePaths.Identifiers
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
