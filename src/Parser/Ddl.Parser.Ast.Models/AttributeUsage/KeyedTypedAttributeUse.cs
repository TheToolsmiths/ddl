using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Identifiers;
using TheToolsmiths.Ddl.Parser.Ast.Models.Values;
using TheToolsmiths.Ddl.Parser.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Ast.Models.AttributeUsage
{
    public class KeyedTypedAttributeUse : BaseTypedAttributeUse, IKeyedTypedAttributeUse
    {
        public KeyedTypedAttributeUse(Identifier key, ITypeIdentifier type, StructValueInitialization initialization)
            : base(type, initialization)
        {
            this.Key = key;
        }

        public KeyedTypedAttributeUse(Identifier key, TypedStructValueInitialization initialization)
            : this(key, initialization.Type, initialization.Initialization)
        {
        }

        public override AttributeUseKind UseKind => AttributeUseKind.KeyedTyped;

        public override bool IsKeyed => true;

        public override bool IsTyped => true;

        public Identifier Key { get; }
    }
}
