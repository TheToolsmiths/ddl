using TheToolsmiths.Ddl.Models.Build.Values;
using TheToolsmiths.Ddl.Models.Types.Usage;

namespace TheToolsmiths.Ddl.Models.Build.AttributeUsage
{
    public abstract class TypedInitializationUse : BaseTypedAttributeUse
    {
        protected TypedInitializationUse(
            TypeUse type, 
            StructInitialization initialization)
            : base(type, initialization)
        {
        }

        public override bool IsKeyed => false;
    }
}
