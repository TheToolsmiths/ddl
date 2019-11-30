namespace TheToolsmiths.Ddl.Models
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
