using TheToolsmiths.Ddl.Models.Build.Types.Usage;
using TheToolsmiths.Ddl.Models.Build.Values;

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
