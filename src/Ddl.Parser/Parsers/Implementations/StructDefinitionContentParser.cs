using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.Identifiers;
using TheToolsmiths.Ddl.Models.Structs;
using TheToolsmiths.Ddl.Models.Types;
using TheToolsmiths.Ddl.Models.Values;
using TheToolsmiths.Ddl.Parser.Lexers;

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
                var result = await context.Lexer.TryPeekToken();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var token = result.Token;

                switch (token.Kind)
                {
                    case LexerTokenKind.CloseScope:
                        return CreateStructBodyResult();
                    case LexerTokenKind.ListSeparator:
                        context.Lexer.PopToken();
                        break;
                    case LexerTokenKind.Identifier:
                        {
                            var definitionResult = await this.ParseStructDefinitionItem(context);

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

        private async Task<ParseResult<IStructDefinitionItem>> ParseStructDefinitionItem(IParserContext context)
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

            return await this.ParseStructFieldDefinition(context);
        }

        private async Task<ParseResult<IStructDefinitionItem>> ParseStructFieldDefinition(IParserContext context)
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


            var attributes = Array.Empty<IAttributeUse>();

            var field = new FieldDefinition(fieldName, fieldType, initialization, attributes);

            return new ParseResult<IStructDefinitionItem>(field);
        }
    }
}
