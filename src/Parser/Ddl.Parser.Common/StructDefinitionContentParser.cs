using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Parser.Contexts;
using TheToolsmiths.Ddl.Parser.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Parser.Models.Identifiers;
using TheToolsmiths.Ddl.Parser.Models.Structs;
using TheToolsmiths.Ddl.Parser.Models.Types;
using TheToolsmiths.Ddl.Parser.Models.Values;

namespace TheToolsmiths.Ddl.Parser.Common
{
    public class StructDefinitionContentParser
    {
        public async Task<ParseResult<StructDefinitionContent>> Parse(IParserContext context)
        {
            var items = new List<IStructDefinitionItem>();

            ParseResult<StructDefinitionContent> CreateStructBodyResult()
            {
                var value = new StructDefinitionContent(items);

                return new ParseResult<StructDefinitionContent>(value);
            }

            while (true)
            {
                IReadOnlyList<IAttributeUse> attributesList;
                {
                    var result = await context.Parsers.ParseAttributeUseList();

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    attributesList = result.Value;
                }

                LexerToken token;
                {
                    var result = await context.Lexer.TryPeekToken();

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    token = result.Token;
                }

                switch (token.Kind)
                {
                    case LexerTokenKind.CloseScope:
                        return CreateStructBodyResult();
                    case LexerTokenKind.ListSeparator:
                        context.Lexer.PopToken();
                        break;
                    case LexerTokenKind.Identifier:
                        {
                            var definitionResult = await this.ParseStructDefinitionItem(context, attributesList);

                            if (definitionResult.IsSuccess == false)
                            {
                                throw new NotImplementedException();
                            }

                            items.Add(definitionResult.Value);
                        }
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        private async Task<ParseResult<IStructDefinitionItem>> ParseStructDefinitionItem(
            IParserContext context,
            IReadOnlyList<IAttributeUse> attributesList)
        {
            {
                var result = await context.Lexer.TryPeekIdentifierToken();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var token = result.Token;

                // If its a scope identifier
                if (token.Memory.Span.SequenceEqual(ParserIdentifierConstants.Scope))
                {
                }
            }

            if (await CheckIsScopeToken(context))
            {
                return await this.ParseStructScopeBlock(context);
            }

            var parseResult = await this.ParseStructFieldDefinition(context, attributesList);

            if (await CheckTokenFollowingFieldIsValid(context) == false)
            {
                throw new NotImplementedException();
            }

            return parseResult;


            static async Task<bool> CheckIsScopeToken(IParserContext context)
            {
                var result = await context.Lexer.TryPeekIdentifierToken();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var token = result.Token;

                // If its a scope identifier
                return token.Memory.Span.SequenceEqual(ParserIdentifierConstants.Scope);
            }

            static async Task<bool> CheckTokenFollowingFieldIsValid(IParserContext context)
            {
                var result = await context.Lexer.TryPeekToken();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var token = result.Token;

                return token.IsListSeparator() || token.IsCloseScope();
            }
        }

        private async Task<ParseResult<IStructDefinitionItem>> ParseStructScopeBlock(IParserContext context)
        {
            context.Lexer.PopToken();

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

                var result = await this.Parse(context);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var content = result.Value;

                if (await context.Lexer.TryConsumeCloseScopeToken() == false)
                {
                    throw new NotImplementedException();
                }

                IStructDefinitionItem value = new StructScope(expression, content);
                return new ParseResult<IStructDefinitionItem>(value);
            }
        }

        private async Task<ParseResult<IStructDefinitionItem>> ParseStructFieldDefinition(
            IParserContext context,
            IReadOnlyList<IAttributeUse> attributesList)
        {
            FieldName fieldName;
            {
                var result = await context.Lexer.TryGetIdentifierToken();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var nameIdentifierToken = result.Token;

                var name = new Identifier(nameIdentifierToken.Memory.ToString());
                fieldName = new FieldName(name);
            }

            // Skip value assigment token
            {
                var result = await context.Lexer.TryPeekValueAssignmentToken();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                context.Lexer.PopToken();
            }

            ITypeIdentifier fieldType;
            {
                var result = await context.Parsers.ParseTypeIdentifier();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                fieldType = result.Value;
            }

            ValueInitialization initialization;
            {
                var result = await context.Lexer.TryPeekToken();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var token = result.Token;

                if (token.Kind == LexerTokenKind.FieldInitialization)
                {
                    context.Lexer.PopToken();

                    var parseResult = await context.Parsers.ParseFieldInitialization();

                    if (parseResult.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    initialization = parseResult.Value;
                }
                else
                {
                    initialization = ValueInitialization.CreateEmpty();
                }
            }

            var field = new FieldDefinition(fieldName, fieldType, initialization, attributesList);

            return new ParseResult<IStructDefinitionItem>(field);
        }
    }
}
