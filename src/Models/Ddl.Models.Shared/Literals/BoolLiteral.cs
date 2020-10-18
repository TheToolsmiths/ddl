namespace TheToolsmiths.Ddl.Models.Literals
{
    public class BoolLiteral : LiteralValue
    {
        public BoolLiteral(in bool value)
        {
            this.Value = value;
        }

        public bool Value { get; }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
