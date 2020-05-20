using TheToolsmiths.Ddl.Parser.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Models.Structs
{
    public class FieldName
    {
        public FieldName(Identifier name)
        {
            this.Name = name;
        }

        public Identifier Name { get; }

        public override string ToString()
        {
            return this.Name.ToString();
        }
    }
}
