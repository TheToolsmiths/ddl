namespace TheToolsmiths.Ddl.Models.Compiled.Literals
{
    public abstract class LiteralValue
    {
        protected LiteralValue(string text)
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
