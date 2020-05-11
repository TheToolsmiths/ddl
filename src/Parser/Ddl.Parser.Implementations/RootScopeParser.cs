using System;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Parser.Contexts;
using TheToolsmiths.Ddl.Parser.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Scopes;

namespace TheToolsmiths.Ddl.Parser.Implementations
{
    internal class RootScopeParser : IRootScopeParser
    {
        private readonly IRootScopeContentParser rootScopeContentParser;

        public RootScopeParser(IRootScopeContentParser rootScopeContentParser)
        {
            this.rootScopeContentParser = rootScopeContentParser;
        }

        public async ValueTask<RootParseResult<IRootScope>> ParseRootScope(IRootScopeParserContext context)
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

                var result = await this.rootScopeContentParser.ParseRootScopeContent(context.ParserContext);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var rootContent = result.Value;

                if (await context.Lexer.TryConsumeCloseScopeToken() == false)
                {
                    throw new NotImplementedException();
                }

                var value = new ConditionalRootScope(expression, rootContent);

                return RootParseResult<IRootScope>.FromResult(value);
            }
        }
    }
}
