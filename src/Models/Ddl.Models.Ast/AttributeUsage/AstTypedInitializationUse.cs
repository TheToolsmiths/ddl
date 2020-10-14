using TheToolsmiths.Ddl.Models.Ast.Types.Identifiers;
using TheToolsmiths.Ddl.Models.Ast.Values;

namespace TheToolsmiths.Ddl.Models.Ast.AttributeUsage
{
    public abstract class AstTypedInitializationUse : BaseTypedAstAttributeUse
    {
        protected AstTypedInitializationUse(
            ITypeIdentifier type, 
            StructValueInitialization initialization)
            : base(type, initialization)
        {
        }

        public override bool IsKeyed => false;
    }
}
