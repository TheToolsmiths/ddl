using TheToolsmiths.Ddl.Models.Build.Values;
using TheToolsmiths.Ddl.Models.Types.Usage;

namespace TheToolsmiths.Ddl.Models.Build.AttributeUsage
{
    public abstract class BaseTypedAttributeUse : BaseStructInitializationAttributeUse, ITypedAttributeUse
    {
        protected BaseTypedAttributeUse(
            TypeUse type,
            StructInitialization initialization)
        : base(initialization)
        {
            this.Type = type;
        }

        public TypeUse Type { get; }

        public override AttributeUseKind UseKind => AttributeUseKind.Typed;

        public override bool IsTyped => true;
    }
}
