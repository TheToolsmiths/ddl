using System;
using TheToolsmiths.Ddl.Models.Ast.Values;

namespace TheToolsmiths.Ddl.Models.Ast.AttributeUsage
{
    public abstract class BaseStructInitializationAstAttributeUse : BaseAstAttributeUse, IStructInitializationAstAttributeUse
    {
        protected BaseStructInitializationAstAttributeUse(StructValueInitialization initialization)
        {
            this.Initialization = initialization;
        }

        public StructValueInitialization Initialization { get; }

        public override AttributeUseKind UseKind => throw new NotImplementedException();

        public override bool IsTyped => false;
    }
}
