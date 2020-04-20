using TheToolsmiths.Ddl.Parser.Models.Types;
using TheToolsmiths.Ddl.Parser.Models.Values;

namespace TheToolsmiths.Ddl.Parser.Models.AttributeUsage
{
    public class TypedStructInitializationUse : TypedInitializationUse
    {
        public TypedStructInitializationUse(
            ITypeIdentifier type, 
            StructValueInitialization initialization)
            : base(type, initialization)
        {
        }

        public override bool IsKeyed => false;
    }
}
