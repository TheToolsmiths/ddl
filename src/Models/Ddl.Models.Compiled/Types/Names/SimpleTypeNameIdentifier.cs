using TheToolsmiths.Ddl.Models.Compiled.Paths;

namespace TheToolsmiths.Ddl.Models.Compiled.Types.Names
{
    public class SimpleTypeNameIdentifier : TypeNameIdentifier
    {
        public SimpleTypeNameIdentifier(string name)
            : base(name)
        {
        }

        public override PathPartKind IdentifierKind => PathPartKind.Simple;

        public override string ToString()
        {
            return this.Name;
        }
    }
}
