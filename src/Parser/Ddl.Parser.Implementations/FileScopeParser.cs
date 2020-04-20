using System;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Parser.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Parser.Models.FileContents;
using TheToolsmiths.Ddl.Parser.Shared;
using TheToolsmiths.Ddl.Parser.Shared.Contexts;

namespace TheToolsmiths.Ddl.Parser.Implementations
{
    internal class FileScopeParser : IRootItemParser
    {
        private readonly IFileRootContentParser rootContentParser;

        public FileScopeParser(IFileRootContentParser rootContentParser)
        {
            this.rootContentParser = rootContentParser;
        }

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
                var parseResult = await context.Parsers.ParseConditionalExpressionRoot();

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

                var result = await this.rootContentParser.ParseRootContentScope(context.ParserContext);

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
