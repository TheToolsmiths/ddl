using TheToolsmiths.Ddl.Parser.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Models.Values
{
    public class FieldValueInitialization
    {
        public FieldValueInitialization(
            Identifier name,
            ValueInitialization initialization)
        {
            this.Name = name;
            this.Initialization = initialization;
        }

        public Identifier Name { get; }

        public ValueInitialization Initialization { get; }
    }
}
