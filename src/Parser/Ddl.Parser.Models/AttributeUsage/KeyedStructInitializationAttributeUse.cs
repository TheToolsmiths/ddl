using TheToolsmiths.Ddl.Parser.Models.Values;

namespace TheToolsmiths.Ddl.Parser.Models.AttributeUsage
{
    public class KeyedStructInitializationAttributeUse : BaseStructInitializationAttributeUse, IKeyedStructInitializationAttributeUse
    {
        public KeyedStructInitializationAttributeUse(string key, StructValueInitialization initialization)
            : base(initialization)
        {
            this.Key = key;
        }

        public override AttributeUseKind UseKind => AttributeUseKind.KeyedStructInitialization;

        public override bool IsKeyed => true;

        public override bool IsTyped => false;

        public string Key { get; }
    }
}
