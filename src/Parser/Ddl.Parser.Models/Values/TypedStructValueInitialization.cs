using TheToolsmiths.Ddl.Parser.Models.Types;
using TheToolsmiths.Ddl.Parser.Models.Types.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Models.Values
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
