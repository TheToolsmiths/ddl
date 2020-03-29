using TheToolsmiths.Ddl.Models.Types;
using TheToolsmiths.Ddl.Models.Values;

namespace TheToolsmiths.Ddl.Models.AttributeUsage
{
    public abstract class BaseTypedAttributeUse : BaseStructInitializationAttributeUse, ITypedAttributeUse
    {
        protected BaseTypedAttributeUse(ITypeIdentifier type, StructValueInitialization initialization)
        : base(initialization)
        {
            this.Type = type;
            this.Initialization = initialization;
        }

        public ITypeIdentifier Type { get; }

        public StructValueInitialization Initialization { get; }

        public override AttributeUseType UseType => AttributeUseType.Typed;

        public override bool IsTyped => true;
    }
}
