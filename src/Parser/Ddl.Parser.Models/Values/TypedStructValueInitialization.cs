using TheToolsmiths.Ddl.Parser.Models.Types.References;

namespace TheToolsmiths.Ddl.Parser.Models.Values
{
    public class TypedStructValueInitialization
    {
        public TypedStructValueInitialization(TypeReference type, StructValueInitialization initialization)
        {
            this.Type = type;
            this.Initialization = initialization;
        }

        public TypeReference Type { get; }

        public StructValueInitialization Initialization { get; }
    }
}
