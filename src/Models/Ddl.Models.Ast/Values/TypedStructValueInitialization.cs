using TheToolsmiths.Ddl.Models.Ast.Types.Identifiers;

namespace TheToolsmiths.Ddl.Models.Ast.Values
{
    public class TypedStructValueInitialization
    {
        public TypedStructValueInitialization(ITypeIdentifier type, StructValueInitialization initialization)
        {
            this.Type = type;
            this.Initialization = initialization;
        }

        public ITypeIdentifier Type { get; }

        public StructValueInitialization Initialization { get; }
    }
}
