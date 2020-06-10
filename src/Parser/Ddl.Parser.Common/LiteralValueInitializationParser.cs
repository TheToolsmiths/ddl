using System;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Parser.Contexts;
using TheToolsmiths.Ddl.Parser.Models.Literals;

namespace TheToolsmiths.Ddl.Parser.Common
{
    public class LiteralValueInitializationParser
    {
        public async Task<Result<LiteralValue>> ParseLiteralValue(IParserContext context)
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
                    var value = new DefaultLiteral();
                    return Result.FromValue<LiteralValue>(value);
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

                LiteralValue literalValue = token.Kind switch
                {
                    LexerTokenKind.String => new StringLiteral(token.Memory.ToString()),
                    LexerTokenKind.Number => new NumberLiteral(token.Memory.ToString()),
                    LexerTokenKind.Boolean => new BoolLiteral(token.Memory.ToString()),
                    _ => throw new ArgumentOutOfRangeException()
                };

                return Result.FromValue(literalValue);
            }
        }
    }
}
