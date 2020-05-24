using TheToolsmiths.Ddl.Parser.Models.Types;
using TheToolsmiths.Ddl.Parser.Models.Values;

namespace TheToolsmiths.Ddl.Parser.Models.AttributeUsage
{
    public abstract class BaseTypedAttributeUse : BaseStructInitializationAttributeUse, ITypedAttributeUse
    {
        protected BaseTypedAttributeUse(
            ResolvedType type,
            StructValueInitialization initialization)
        : base(initialization)
        {
            this.Type = type;
        }

        public ResolvedType Type { get; }

        public override AttributeUseKind UseKind => AttributeUseKind.Typed;

        public override bool IsTyped => true;
    }
}
