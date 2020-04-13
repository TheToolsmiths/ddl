using System;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Models.Literals;
using TheToolsmiths.Ddl.Parser.Contexts;

namespace TheToolsmiths.Ddl.Parser.Parsers.Implementations
{
    internal class LiteralValueInitializationParser
    {
        public async Task<ParseResult<LiteralValue>> ParseLiteralValue(IParserContext context)
        {
            if (await context.Lexer.IsNextIdentifierToken())
            {
                var result = await context.Lexer.TryGetIdentifierToken();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var token = result.Token;

                if (token.Memory.Span.SequenceEqual(ParserIdentifierConstants.Default))
                {
                    var value = LiteralValue.CreateDefault();
                    return new ParseResult<LiteralValue>(value);
                }
            }

            {
                var result = await context.Lexer.TryGetLiteralToken();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                LexerToken token;
                token = result.Token;

                var type = token.Kind switch
                {
                    LexerTokenKind.String => LiteralValueType.StringLiteral,
                    LexerTokenKind.Number => LiteralValueType.NumberLiteral,
                    LexerTokenKind.Boolean => LiteralValueType.BooleanLiteral,
                    _ => throw new ArgumentOutOfRangeException()
                };

                string text = token.Memory.ToString();

                var value = new LiteralValue(type, text);

                return new ParseResult<LiteralValue>(value);
            }
        }
    }
}
