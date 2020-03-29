using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.Identifiers;
using TheToolsmiths.Ddl.Models.Structs;
using TheToolsmiths.Ddl.Models.Types;
using TheToolsmiths.Ddl.Models.Values;
using TheToolsmiths.Ddl.Parser.Contexts;

namespace TheToolsmiths.Ddl.Parser.Parsers.Implementations
{
    internal class StructDefinitionContentParser
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
                LexerToken token;
                {
                    var result = await context.Lexer.TryPeekToken();

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    token = result.Token;
                }

                IReadOnlyList<IAttributeUse> attributesList;
                if (token.IsOpenAttribute())
                {
                    var parseResult = await context.Parsers.ParseAttributeUseList(context);

                    if (parseResult.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    attributesList = parseResult.Value;

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
                    attributesList = Array.Empty<IAttributeUse>();
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
            var result = await context.Lexer.TryPeekIdentifierToken();

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var token = result.Token;

            // If its a scope identifier
            if (token.Memory.Span.SequenceEqual(ParserIdentifierConstants.Scope))
            {
                context.Lexer.PopToken();
                throw new NotImplementedException();
            }

            return await this.ParseStructFieldDefinition(context, attributesList);
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
                var result = await context.Parsers.ParseTypeIdentifier(context);

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
                    throw new NotImplementedException();
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
