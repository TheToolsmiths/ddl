using System;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Models.FileContents;
using TheToolsmiths.Ddl.Parser.Contexts;

namespace TheToolsmiths.Ddl.Parser.Parsers.Implementations
{
    internal class FileScopeParser : IRootParser
    {
        public async ValueTask<RootParseResult<IRootContentItem>> ParseRootContent(IRootItemParserContext context)
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

            ConditionalExpression expression;
            if (token.IsOpenParentheses())
            {
                var parseResult = await context.Parsers.ParseConditionalExpressionRoot(context);

                if (parseResult.IsError)
                {
                    throw new NotImplementedException();
                }

                expression = parseResult.Value;

                {
                    var result = await context.Lexer.TryPeekToken();

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    token = result.Token;
                }
            }
            else
            {
                expression = ConditionalExpression.CreateEmpty();
            }

            if (token.IsOpenScope() == false)
            {
                throw new NotImplementedException();
            }

            {
                context.Lexer.PopToken();

                var result = await context.Parsers.ParseRootContentScope(context.RootParserContext);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var content = result.Value;

                if (await context.Lexer.TryConsumeCloseScopeToken() == false)
                {
                    throw new NotImplementedException();
                }

                var value = new RootScope(expression, content);
                return RootParseResult<IRootContentItem>.FromResult(value);
            }
        }
    }
}
