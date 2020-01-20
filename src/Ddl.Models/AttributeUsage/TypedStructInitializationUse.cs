using TheToolsmiths.Ddl.Models.Types;
using TheToolsmiths.Ddl.Models.Values;

namespace TheToolsmiths.Ddl.Models.AttributeUsage
{
    public abstract class TypedInitializationUse : BaseTypedAttributeUse
    {
        protected TypedInitializationUse(
            TypeIdentifier type, 
            StructValueInitialization initialization)
            : base(type, initialization)
        {
        }

        public override bool IsKeyed => false;
    }

    public class TypedStructInitializationUse : TypedInitializationUse
    {
        public TypedStructInitializationUse(
            TypeIdentifier type, 
            StructValueInitialization initialization)
            : base(type, initialization)
        {
        }

        public override bool IsKeyed => false;
    }

    public class TypedConstructorInitializationUse : TypedInitializationUse
    {
        public TypedConstructorInitializationUse(
            TypeIdentifier type,
            StructValueInitialization initialization)
            : base(type, initialization)
        {
        }

        public override bool IsKeyed => false;
    }
}
