namespace TheToolsmiths.Ddl.Parser.Models
{
    public class FieldName
    {
        public FieldName(Identifier name)
        {
            Name = name;
        }

        public Identifier Name { get; }
    }
}
