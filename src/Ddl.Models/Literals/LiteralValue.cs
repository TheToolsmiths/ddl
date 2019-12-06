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
    }
}
