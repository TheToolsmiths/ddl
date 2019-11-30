namespace TheToolsmiths.Ddl.Models
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
    }
}
