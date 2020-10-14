using System.Globalization;

namespace TheToolsmiths.Ddl.Models.Build.Literals
{
    public class BoolLiteral : LiteralValue
    {
        public BoolLiteral(string text)
            : base(text)
        {
        }

        public BoolLiteral(in bool value)
            : base(value.ToString(CultureInfo.InvariantCulture))
        {
        }
    }
}
