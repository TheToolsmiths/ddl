using TheToolsmiths.Ddl.Models.Ast.Types.Identifiers;
using TheToolsmiths.Ddl.Models.Ast.Values;

namespace TheToolsmiths.Ddl.Models.Ast.AttributeUsage
{
    public abstract class BaseTypedAstAttributeUse : BaseStructInitializationAstAttributeUse, ITypedAstAttributeUse
    {
        protected BaseTypedAstAttributeUse(
            ITypeIdentifier type,
            StructValueInitialization initialization)
        : base(initialization)
        {
            this.Type = type;
        }

        public ITypeIdentifier Type { get; }

        public override AttributeUseKind UseKind => AttributeUseKind.Typed;

        public override bool IsTyped => true;
    }
}
