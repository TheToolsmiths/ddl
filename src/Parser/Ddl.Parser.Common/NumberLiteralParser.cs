using System;
using System.Globalization;
using TheToolsmiths.Ddl.Parser.Ast.Models.Literals;

namespace TheToolsmiths.Ddl.Parser.Common
{
    public static class NumberLiteralParser
    {
        public static bool TryParseInteger(NumberLiteral literal, out int value)
        {
            var literalText = literal.Text.AsSpan();

            if (int.TryParse(literalText, out value))
            {
                return true;
            }

            if (literalText.StartsWith("0x"))
            {
                return int.TryParse(literalText,
                    NumberStyles.HexNumber | NumberStyles.AllowHexSpecifier,
                    CultureInfo.CurrentCulture,
                    out value);
            }

            if (literalText.StartsWith("0b"))
            {
                literalText = literalText.Slice(2);

                Span<byte> span = stackalloc byte[4];

                if (TryReadBitStringTo4Bytes(span, literalText) == false)
                {
                    return false;
                }

                value = (int)BitConverter.ToUInt32(span);

                return true;
            }

            throw new NotImplementedException();
        }

        private static bool TryReadBitStringTo4Bytes(Span<byte> memory, in ReadOnlySpan<char> literalText)
        {
            if (memory.Length != 4)
            {
                return false;
            }

            if (literalText.Length > 31)
            {
                return false;
            }

            int byteLength = (literalText.Length + 7) / 8;

            for (int b = 0, i = 0; b < byteLength; b++)
            {
                for (int l = 0; l < 8; l++, i++)
                {
                    if (i >= literalText.Length)
                    {
                        return true;
                    }

                    switch (literalText[i])
                    {
                        case '0':
                            break;
                        case '1':
                            memory[b] = (byte)(memory[b] | 1 << l);
                            break;
                        default:
                            return false;
                    }
                }
            }

            return true;
        }
    }
}
