namespace TheToolsmiths.Ddl.Models.AttributeUsage
{
    public class KeyedTypedAttributeUse : BaseTypedAttributeUse, IKeyedTypedAttributeUse
    {
        public KeyedTypedAttributeUse(Identifier key, TypeIdentifier type, StructValueInitialization initialization)
            : base(type, initialization)
        {
            Key = key;
        }

        public override AttributeUseType UseType => AttributeUseType.KeyedTyped;

        public override bool IsKeyed => true;

        public override bool IsTyped => true;

        public Identifier Key { get; }
    }
}