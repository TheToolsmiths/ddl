namespace TheToolsmiths.Ddl.Parser.Models
{
    public class TypeName
    {
        public TypeName(Identifier name)
        {
            Name = name;
        }

        public Identifier Name { get; }
    }
}
