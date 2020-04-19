using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Models.Identifiers;
using TheToolsmiths.Ddl.Models.Literals;
using TheToolsmiths.Ddl.Models.Structs;
using TheToolsmiths.Ddl.Models.Values;
using TheToolsmiths.Ddl.Parser.Shared;
using TheToolsmiths.Ddl.Parser.Shared.Contexts;

namespace TheToolsmiths.Ddl.Parser.Common
{
    public class StructValueInitializationParser
    {
        public async Task<ParseResult<StructValueInitialization>> ParseStructuredInitialization(IParserContext context)
        {
            if (await context.Lexer.TryConsumeOpenScopeToken() == false)
            {
                throw new NotImplementedException();
            }

            IEnumerable<FieldValueInitialization> fields;
            {
                var result = await this.ParseStructuredInitializationFields(context);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                fields = result.Value;
            }

            if (await context.Lexer.TryConsumeCloseScopeToken() == false)
            {
                throw new NotImplementedException();
            }

            var value = new StructValueInitialization(fields);
            return new ParseResult<StructValueInitialization>(value);
        }

        private async Task<ParseResult<ValueInitialization>> ParseStructuredInitializationValue(
            IParserContext context)
        {
            var result = await context.Lexer.TryPeekToken();

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var token = result.Token;

            return token.Kind switch
            {
                LexerTokenKind.OpenScope => await ParseStructuredInitialization(),
                LexerTokenKind.String => CreateStringInitialization(),
                LexerTokenKind.Number => CreateNumberInitialization(),
                LexerTokenKind.Boolean => CreateBoolInitialization(),
                LexerTokenKind.Identifier => await CreateTypeIdentifierInitialization(),
                _ => throw new ArgumentOutOfRangeException()
            };

            async Task<ParseResult<ValueInitialization>> ParseStructuredInitialization()
            {
                var parseResult = await context.Parsers.ParseStructValueInitialization();

                if (parseResult.IsError)
                {
                    throw new NotImplementedException();
                }

                var initialization = parseResult.Value;

                return new ParseResult<ValueInitialization>(initialization);
            }

            ParseResult<ValueInitialization> CreateStringInitialization()
            {
                context.Lexer.PopToken();

                var literal = new LiteralValue(LiteralValueType.StringLiteral, token.Memory.ToString());

                var value = new LiteralValueInitialization(literal);
                return new ParseResult<ValueInitialization>(value);
            }

            ParseResult<ValueInitialization> CreateNumberInitialization()
            {
                context.Lexer.PopToken();

                var literal = new LiteralValue(LiteralValueType.NumberLiteral, token.Memory.ToString());

                var value = new LiteralValueInitialization(literal);
                return new ParseResult<ValueInitialization>(value);
            }

            ParseResult<ValueInitialization> CreateBoolInitialization()
            {
                context.Lexer.PopToken();

                var literal = new LiteralValue(LiteralValueType.BooleanLiteral, token.Memory.ToString());

                var value = new LiteralValueInitialization(literal);
                return new ParseResult<ValueInitialization>(value);
            }

            async Task<ParseResult<ValueInitialization>> CreateTypeIdentifierInitialization()
            {
                var typeResult = await context.Parsers.ParseTypeIdentifier();

                if (typeResult.IsError)
                {
                    throw new NotImplementedException();
                }

                var value = new TypeIdentifierInitialization(typeResult.Value);

                return new ParseResult<ValueInitialization>(value);
            }
        }

        private async Task<ParseResult<IReadOnlyList<FieldValueInitialization>>> ParseStructuredInitializationFields(
            IParserContext context)
        {
            var fields = new List<FieldValueInitialization>();

            while (true)
            {
                FieldName name;
                {
                    var result = await context.Lexer.TryPeekToken();

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    var token = result.Token;

                    if (token.Kind == LexerTokenKind.ListSeparator)
                    {
                        context.Lexer.PopToken();
                        continue;
                    }

                    if (token.Kind != LexerTokenKind.Identifier)
                    {
                        break;
                    }

                    context.Lexer.PopToken();

                    var identifier = new Identifier(token.Memory.ToString());

                    name = new FieldName(identifier);
                }

                {
                    if (await context.Lexer.TryConsumeValueAssignmentToken() == false)
                    {
                        throw new NotImplementedException();
                    }
                }

                ValueInitialization initialization;
                {
                    var result = await this.ParseStructuredInitializationValue(context);

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    initialization = result.Value;
                }

                var field = new FieldValueInitialization(name, initialization);
                fields.Add(field);
            }

            return new ParseResult<IReadOnlyList<FieldValueInitialization>>(fields);
        }
    }
}
