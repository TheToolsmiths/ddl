using TheToolsmiths.Ddl.Models.Types;
using TheToolsmiths.Ddl.Models.Values;

namespace TheToolsmiths.Ddl.Models.AttributeUsage
{
    public class TypedConstructorInitializationUse : TypedInitializationUse
    {
        public TypedConstructorInitializationUse(
            ITypeIdentifier type,
            StructValueInitialization initialization)
            : base(type, initialization)
        {
        }

        public override bool IsKeyed => false;
    }
}