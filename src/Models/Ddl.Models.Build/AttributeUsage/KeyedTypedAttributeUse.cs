using TheToolsmiths.Ddl.Models.Build.Values;
using TheToolsmiths.Ddl.Models.Types.Usage;

namespace TheToolsmiths.Ddl.Models.Build.AttributeUsage
{
    public class KeyedTypedAttributeUse : BaseTypedAttributeUse, IKeyedTypedAttributeUse
    {
        public KeyedTypedAttributeUse(string key, TypeUse type, StructInitialization initialization)
            : base(type, initialization)
        {
            this.Key = key;
        }

        public KeyedTypedAttributeUse(string key, TypedStructInitialization initialization)
            : this(key, initialization.Type, initialization.Initialization)
        {
        }

        public override AttributeUseKind UseKind => AttributeUseKind.KeyedTyped;

        public override bool IsKeyed => true;

        public override bool IsTyped => true;

        public string Key { get; }
    }
}
