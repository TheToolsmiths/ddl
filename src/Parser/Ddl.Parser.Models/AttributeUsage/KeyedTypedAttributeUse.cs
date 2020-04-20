using TheToolsmiths.Ddl.Parser.Models.Identifiers;
using TheToolsmiths.Ddl.Parser.Models.Types;
using TheToolsmiths.Ddl.Parser.Models.Values;

namespace TheToolsmiths.Ddl.Parser.Models.AttributeUsage
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

        public override AttributeUseType UseType => AttributeUseType.KeyedTyped;

        public override bool IsKeyed => true;

        public override bool IsTyped => true;

        public Identifier Key { get; }
    }
}
