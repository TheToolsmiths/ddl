using System;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Models.FileContents;
using TheToolsmiths.Ddl.Parser.Lexers;

namespace TheToolsmiths.Ddl.Parser.Parsers
{
    internal class EnumStructDefinitionParser : IRootParser<RootParserContext>
    {
        public async ValueTask<ParseResult<IRootContentItem>> ParseRootContent(RootParserContext context)
        {
            {
                var result = await context.Lexer.TryGetIdentifierToken();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var token = result.Token;
            }

            {
                var result = await context.Lexer.TryGetNextToken();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var token = result.Token;

                if (token.Kind == LexerTokenKind.OpenScope)
                {
                    return await this.ParseBlockContent(context);
                }
            }

            throw new NotImplementedException();
        }

        private async Task<ParseResult<IRootContentItem>> ParseBlockContent(RootParserContext context)
        {
            while (true)
            {
                // Parse enum struct Identifier
                {
                    var result = await context.Lexer.TryPeekToken();

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    var identifier = result.Token;

                    if (identifier.Kind == LexerTokenKind.CloseScope)
                    {
                        throw new NotImplementedException();
                        break;
                    }

                    if (identifier.Kind != LexerTokenKind.Identifier)
                    {
                        throw new NotImplementedException();
                    }

                    context.Lexer.PopToken();
                }

                // Parse Variant OpenScope token
                {
                    var result = await context.Lexer.TryGetNextToken();

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    var identifier = result.Token;

                    if (identifier.Kind != LexerTokenKind.OpenScope)
                    {
                        throw new NotImplementedException();
                    }
                }

                {
                    var result = await context.Parsers.ParseStructDefinitionContentParser(context);

                    throw new NotImplementedException();
                }

                // Parse Variant CloseScope token
                {
                    var result = await context.Lexer.TryGetNextToken();

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    var identifier = result.Token;

                    if (identifier.Kind != LexerTokenKind.CloseScope)
                    {
                        throw new NotImplementedException();
                    }
                }
            }

            throw new NotImplementedException();
        }
    }
}
