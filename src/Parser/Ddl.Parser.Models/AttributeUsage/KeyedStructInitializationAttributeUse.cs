using TheToolsmiths.Ddl.Parser.Models.Identifiers;
using TheToolsmiths.Ddl.Parser.Models.Values;

namespace TheToolsmiths.Ddl.Parser.Models.AttributeUsage
{
    public class KeyedStructInitializationAttributeUse : BaseStructInitializationAttributeUse, IKeyedStructInitializationAttributeUse
    {
        public KeyedStructInitializationAttributeUse(Identifier key, StructValueInitialization initialization)
            : base(initialization)
        {
            this.Key = key;
        }

        public override AttributeUseType UseType => AttributeUseType.KeyedStructInitialization;

        public override bool IsKeyed => true;

        public override bool IsTyped => false;

        public Identifier Key { get; }
    }
}
