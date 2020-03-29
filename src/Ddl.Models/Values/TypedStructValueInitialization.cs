using TheToolsmiths.Ddl.Models.Types;

namespace TheToolsmiths.Ddl.Models.Values
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
