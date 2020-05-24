using TheToolsmiths.Ddl.Parser.Models.Types;

namespace TheToolsmiths.Ddl.Parser.Models.Values
{
    public class TypedStructValueInitialization
    {
        public TypedStructValueInitialization(ResolvedType type, StructValueInitialization initialization)
        {
            this.Type = type;
            this.Initialization = initialization;
        }

        public ResolvedType Type { get; }

        public StructValueInitialization Initialization { get; }
    }
}
