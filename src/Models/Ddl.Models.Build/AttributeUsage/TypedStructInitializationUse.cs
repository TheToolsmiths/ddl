using TheToolsmiths.Ddl.Models.Build.Values;
using TheToolsmiths.Ddl.Models.Types.Usage;

namespace TheToolsmiths.Ddl.Models.Build.AttributeUsage
{
    public class TypedStructInitializationUse : TypedInitializationUse
    {
        public TypedStructInitializationUse(
            TypeUse type, 
            StructInitialization initialization)
            : base(type, initialization)
        {
        }

        public override bool IsKeyed => false;
    }
}
