using System;
using TheToolsmiths.Ddl.Models.Values;

namespace TheToolsmiths.Ddl.Models.AttributeUsage
{
    public abstract class BaseStructInitializationAttributeUse : BaseAttributeUse, IStructInitializationAttributeUse
    {
        protected BaseStructInitializationAttributeUse(StructValueInitialization initialization)
        {
            this.Initialization = initialization;
        }

        public StructValueInitialization Initialization { get; }

        public override AttributeUseType UseType => throw new NotImplementedException();

        public override bool IsTyped => false;
    }
}
