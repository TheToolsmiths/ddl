namespace TheToolsmiths.Ddl.Models.Literals
{
    public class StringLiteral : LiteralValue
    {
        public StringLiteral(string text)
        {
            this.Text = text;
        }

        public string Text { get; }

        public override string ToString()
        {
            return this.Text;
        }
    }
}
