using System;
using TheToolsmiths.Ddl.Parser.Models.Values;

namespace TheToolsmiths.Ddl.Parser.Models.AttributeUsage
{
    public abstract class BaseStructInitializationAttributeUse : BaseAttributeUse, IStructInitializationAttributeUse
    {
        protected BaseStructInitializationAttributeUse(StructValueInitialization initialization)
        {
            this.Initialization = initialization;
        }

        public StructValueInitialization Initialization { get; }

        public override AttributeUseKind UseKind => throw new NotImplementedException();

        public override bool IsTyped => false;
    }
}
