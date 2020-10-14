using TheToolsmiths.Ddl.Models.Ast.Identifiers;
using TheToolsmiths.Ddl.Models.Ast.Values;

namespace TheToolsmiths.Ddl.Models.Ast.AttributeUsage
{
    public class KeyedStructInitializationAstAttributeUse : BaseStructInitializationAstAttributeUse, IKeyedStructInitializationAstAttributeUse
    {
        public KeyedStructInitializationAstAttributeUse(Identifier key, StructValueInitialization initialization)
            : base(initialization)
        {
            this.Key = key;
        }

        public override AttributeUseKind UseKind => AttributeUseKind.KeyedStructInitialization;

        public override bool IsKeyed => true;

        public override bool IsTyped => false;

        public Identifier Key { get; }
    }
}
