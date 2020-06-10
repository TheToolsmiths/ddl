using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Identifiers;
using TheToolsmiths.Ddl.Parser.Ast.Models.Values;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage
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
