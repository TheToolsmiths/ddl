using TheToolsmiths.Ddl.Models.Ast.Identifiers;

namespace TheToolsmiths.Ddl.Models.Ast.Values
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
