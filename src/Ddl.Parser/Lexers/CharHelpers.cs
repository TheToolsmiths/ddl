namespace TheToolsmiths.Ddl.Parser.Lexers
{
    internal static class CharHelpers
    {
        public static bool IsNewLineChar(in char c)
        {
            return c == CharConstants.LineFeed || c == CharConstants.CarriageReturn;
        }

        public static bool IsIdentifierStart(in char c)
        {
            // If char is outside the ASCII range
            if (IsAscii(c) == false)
            {
                return false;
            }

            return c == CharConstants.Underscore || char.IsLetter(c);
        }

        public static bool IsValidIdentifierChar(in char c)
        {
            // If char is outside the ASCII range
            if (IsAscii(c) == false)
            {
                return false;
            }

            return c == CharConstants.Underscore || char.IsLetterOrDigit(c);
        }

        public static bool IsAscii(in char c)
        {
            return c <= sbyte.MaxValue;
        }
    }
}
