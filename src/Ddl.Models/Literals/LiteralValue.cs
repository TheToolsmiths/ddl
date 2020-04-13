namespace TheToolsmiths.Ddl.Models.Literals
{
    public class LiteralValue
    {
        public LiteralValue(LiteralValueType valueType, string text)
        {
            this.ValueType = valueType;
            this.Text = text;
        }

        public LiteralValueType ValueType { get; }

        public string Text { get; }

        public override string ToString()
        {
            return this.Text;
        }

        public static LiteralValue CreateEmpty()
        {
            return new LiteralValue(LiteralValueType.Empty, string.Empty);
        }

        public static LiteralValue CreateDefault()
        {
            return new LiteralValue(LiteralValueType.Default, string.Empty);
        }
    }
}
