using TheToolsmiths.Ddl.Models.Build.Types.Usage;
using TheToolsmiths.Ddl.Models.Build.Values;

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
