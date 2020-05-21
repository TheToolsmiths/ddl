using TheToolsmiths.Ddl.Parser.Ast.Models.Identifiers;
using TheToolsmiths.Ddl.Parser.Ast.Models.Values;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.Structs
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
