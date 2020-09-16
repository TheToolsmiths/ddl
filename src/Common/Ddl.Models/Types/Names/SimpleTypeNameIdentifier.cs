namespace TheToolsmiths.Ddl.Models.Types.Names
{
    public class SimpleTypeNameIdentifier : TypeNameIdentifier
    {
        public SimpleTypeNameIdentifier(string name)
            : base(name)
        {
        }

        public override TypeNameKind IdentifierKind => TypeNameKind.Simple;

        public override string ToString()
        {
            return this.Name;
        }
    }
}
