using TheToolsmiths.Ddl.Models.Compiled.Values;

namespace TheToolsmiths.Ddl.Models.Compiled.AttributeUsage
{
    public abstract class BaseStructInitializationAttributeUse : BaseAttributeUse, IStructInitializationAttributeUse
    {
        protected BaseStructInitializationAttributeUse(StructInitialization initialization)
        {
            this.Initialization = initialization;
        }

        public StructInitialization Initialization { get; }

        public abstract override AttributeUseKind UseKind { get; }

        public override bool IsTyped => false;
    }
}
