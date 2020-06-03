namespace TheToolsmiths.Ddl.Parser.Models.Types.Names
{
    public class SimpleTypeNameIdentifier : TypeNameIdentifier
    {
        public SimpleTypeNameIdentifier(string name)
            : base(name)
        {
        }

        public override TypeNameIdentifierKind IdentifierKind => TypeNameIdentifierKind.Simple;

        public override string ToString()
        {
            return this.Name;
        }
    }
}
