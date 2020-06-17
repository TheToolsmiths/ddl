﻿using System.Globalization;

namespace TheToolsmiths.Ddl.Models.Literals
{
    public class NumberLiteral : LiteralValue
    {
        public NumberLiteral(string text)
            : base(text)
        {
        }

        public NumberLiteral(in float value)
            : base(value.ToString(CultureInfo.InvariantCulture))
        {
        }
    }
}
