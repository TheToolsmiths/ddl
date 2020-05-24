using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ddl.Common;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Parser.Ast.Models.Literals;
using TheToolsmiths.Ddl.Parser.Ast.Models.Structs;
using TheToolsmiths.Ddl.Parser.Ast.Models.Values;
using TheToolsmiths.Ddl.Parser.Contexts;
using TheToolsmiths.Ddl.Parser.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Common
{
    public class StructValueInitializationParser
    {
        public async Task<Result<StructValueInitialization>> ParseStructuredInitialization(IParserContext context)
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
            return Result.FromValue(value);
        }

        private async Task<Result<ValueInitialization>> ParseStructuredInitializationValue(
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

            async Task<Result<ValueInitialization>> ParseStructuredInitialization()
            {
                var parseResult = await context.Parsers.ParseStructValueInitialization();

                if (parseResult.IsError)
                {
                    throw new NotImplementedException();
                }

                var initialization = parseResult.Value;

                return Result.FromValue<ValueInitialization>(initialization);
            }

            Result<ValueInitialization> CreateStringInitialization()
            {
                context.Lexer.PopToken();

                var literal = new LiteralValue(LiteralValueType.StringLiteral, token.Memory.ToString());

                var value = new LiteralValueInitialization(literal);
                return Result.FromValue<ValueInitialization>(value);
            }

            Result<ValueInitialization> CreateNumberInitialization()
            {
                context.Lexer.PopToken();

                var literal = new LiteralValue(LiteralValueType.NumberLiteral, token.Memory.ToString());

                var value = new LiteralValueInitialization(literal);
                return Result.FromValue<ValueInitialization>(value);
            }

            Result<ValueInitialization> CreateBoolInitialization()
            {
                context.Lexer.PopToken();

                var literal = new LiteralValue(LiteralValueType.BooleanLiteral, token.Memory.ToString());

                var value = new LiteralValueInitialization(literal);
                return Result.FromValue<ValueInitialization>(value);
            }

            async Task<Result<ValueInitialization>> CreateTypeIdentifierInitialization()
            {
                var typeResult = await context.Parsers.ParseTypeIdentifier();

                if (typeResult.IsError)
                {
                    throw new NotImplementedException();
                }

                var value = new TypeIdentifierInitialization(typeResult.Value);

                return Result.FromValue<ValueInitialization>(value);
            }
        }

        private async Task<Result<IReadOnlyList<FieldValueInitialization>>> ParseStructuredInitializationFields(
            IParserContext context)
        {
            var fields = new List<FieldValueInitialization>();

            while (true)
            {
                Identifier name;
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

                    name = new Identifier(token.Memory.ToString());
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

            return Result.FromValue<IReadOnlyList<FieldValueInitialization>>(fields);
        }
    }
}
