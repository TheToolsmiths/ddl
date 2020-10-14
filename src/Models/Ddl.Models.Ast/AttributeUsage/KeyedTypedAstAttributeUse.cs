using TheToolsmiths.Ddl.Models.Ast.Identifiers;
using TheToolsmiths.Ddl.Models.Ast.Types.Identifiers;
using TheToolsmiths.Ddl.Models.Ast.Values;

namespace TheToolsmiths.Ddl.Models.Ast.AttributeUsage
{
    public class KeyedTypedAstAttributeUse : BaseTypedAstAttributeUse, IKeyedTypedAstAttributeUse
    {
        public KeyedTypedAstAttributeUse(Identifier key, ITypeIdentifier type, StructValueInitialization initialization)
            : base(type, initialization)
        {
            this.Key = key;
        }

        public KeyedTypedAstAttributeUse(Identifier key, TypedStructValueInitialization initialization)
            : this(key, initialization.Type, initialization.Initialization)
        {
        }

        public override AttributeUseKind UseKind => AttributeUseKind.KeyedTyped;

        public override bool IsKeyed => true;

        public override bool IsTyped => true;

        public Identifier Key { get; }
    }
}
