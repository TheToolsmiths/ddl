using System;
using TheToolsmiths.Ddl.Models.Values;

namespace TheToolsmiths.Ddl.Models.AttributeUsage
{
    public abstract class BaseStructInitializationAttributeUse : BaseAttributeUse, IStructInitializationAttributeUse
    {
        protected BaseStructInitializationAttributeUse(StructInitialization initialization)
        {
            this.Initialization = initialization;
        }

        public StructInitialization Initialization { get; }

        public override AttributeUseKind UseKind => throw new NotImplementedException();

        public override bool IsTyped => false;
    }
}
