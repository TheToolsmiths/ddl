using System;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Models.Ast.Values;
using TheToolsmiths.Ddl.Parser.Contexts;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Common
{
    public class FieldInitializationParser
    {
        public async Task<Result<ValueInitialization>> ParseFieldInitialization(IParserContext context)
        {
            LexerToken token;
            {
                var result = await context.Lexer.TryPeekToken();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                token = result.Token;
            }

            ValueInitialization value;
            if (token.IsLiteral())
            {
                var result = await context.Parsers.ParseLiteralValue();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var initialization = result.Value;

                value = ValueInitialization.CreateLiteral(initialization);
            }
            else if (token.IsOpenScope())
            {
                var result = await context.Parsers.ParseStructValueInitialization();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                value = result.Value;
            }
            else if (token.IsIdentifier())
            {
                var result = await context.Parsers.ParseTypeIdentifier();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var identifier = result.Value;

                value = new TypeIdentifierInitialization(identifier);
            }
            else
            {
                throw new NotImplementedException();
            }

            return Result.FromValue(value);
        }
    }
}
