using TheToolsmiths.Ddl.Models.Types.References;
using TheToolsmiths.Ddl.Models.Values;

namespace TheToolsmiths.Ddl.Models.AttributeUsage
{
    public class TypedStructInitializationUse : TypedInitializationUse
    {
        public TypedStructInitializationUse(
            TypeReference type, 
            StructInitialization initialization)
            : base(type, initialization)
        {
        }

        public override bool IsKeyed => false;
    }
}
