namespace TheToolsmiths.Ddl.Models.AttributeUsage
{
    public class KeyedLiteralAttributeUse : BaseAttributeUse, IKeyedLiteralAttributeUse
    {
        public KeyedLiteralAttributeUse(Identifier key, LiteralValue literal)
        {
            Key = key;
            Literal = literal;
        }

        public override AttributeUseType UseType => AttributeUseType.KeyedLiteral;

        public override bool IsKeyed => true;

        public override bool IsTyped => false;

        public Identifier Key { get; }

        public LiteralValue Literal { get; }
    }
}