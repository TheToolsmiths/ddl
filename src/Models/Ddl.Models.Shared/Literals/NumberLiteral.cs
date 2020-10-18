using System.Globalization;

namespace TheToolsmiths.Ddl.Models.Literals
{
    public class NumberLiteral : LiteralValue
    {
        private readonly string? text;
        private readonly float? value;

        public NumberLiteral(string text)
        {
            this.text = text;
        }

        public NumberLiteral(in float value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            if (this.value.HasValue)
            {
                return this.value.Value.ToString(NumberFormatInfo.InvariantInfo);
            }

            if (this.text != null)
            {
                return this.text;
            }

            return "0.0";
        }
    }
}
