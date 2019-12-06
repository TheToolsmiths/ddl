using TheToolsmiths.Ddl.Models.Types;
using TheToolsmiths.Ddl.Models.Values;

namespace TheToolsmiths.Ddl.Models.AttributeUsage
{
    public abstract class BaseTypedAttributeUse : BaseAttributeUse, ITypedAttributeUse
    {
        protected BaseTypedAttributeUse(TypeIdentifier type, StructValueInitialization initialization)
        {
            this.Type = type;
            this.Initialization = initialization;
        }

        public TypeIdentifier Type { get; }

        public StructValueInitialization Initialization { get; }
    }
}