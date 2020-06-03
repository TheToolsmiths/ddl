using TheToolsmiths.Ddl.Parser.Models.Types.References;
using TheToolsmiths.Ddl.Parser.Models.Values;

namespace TheToolsmiths.Ddl.Parser.Models.AttributeUsage
{
    public abstract class TypedInitializationUse : BaseTypedAttributeUse
    {
        protected TypedInitializationUse(
            TypeReference type, 
            StructValueInitialization initialization)
            : base(type, initialization)
        {
        }

        public override bool IsKeyed => false;
    }
}
