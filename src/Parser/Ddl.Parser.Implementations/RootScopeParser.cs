using System;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Parser.Ast.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Contexts;

namespace TheToolsmiths.Ddl.Parser.Implementations
{
    internal class RootScopeParser : IRootScopeParser
    {
        private readonly IScopeContentParser scopeContentParser;

        public RootScopeParser(IScopeContentParser scopeContentParser)
        {
            this.scopeContentParser = scopeContentParser;
        }

        public async ValueTask<RootParseResult<IAstRootScope>> ParseRootScope(IRootScopeParserContext context)
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

                var result = await this.scopeContentParser.ParseRootScopeContent(context.ParserContext);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var rootContent = result.Value;

                if (await context.Lexer.TryConsumeCloseScopeToken() == false)
                {
                    throw new NotImplementedException();
                }

                var value = new ConditionalAstRootScope(expression, rootContent);

                return RootParseResult.FromResult<IAstRootScope>(value);
            }
        }
    }
}
