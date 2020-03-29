using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Models.Identifiers;
using TheToolsmiths.Ddl.Models.Types;
using TheToolsmiths.Ddl.Parser.Contexts;

namespace TheToolsmiths.Ddl.Parser.Parsers.Implementations
{
    internal class TypeIdentifierParser
    {
        public async Task<ParseResult<ITypeIdentifier>> Parse(IParserContext context)
        {
            var identifiersList = new List<LexerToken>();

            bool isRootedType = false;

            {
                var result = await context.Lexer.TryPeekToken();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var token = result.Token;

                if (token.IsNamespaceSeparator())
                {
                    context.Lexer.PopToken();
                    isRootedType = true;
                }
            }

            while (true)
            {
                {
                    var result = await context.Lexer.TryPeekIdentifierToken();

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    var identifierToken = result.Token;

                    identifiersList.Add(identifierToken);

                    context.Lexer.PopToken();
                }

                {
                    var result = await context.Lexer.TryPeekToken();

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    var identifierToken = result.Token;

                    switch (identifierToken.Kind)
                    {
                        case LexerTokenKind.NamespaceSeparator:
                            context.Lexer.PopToken();
                            break;

                        // TODO: Add Support for generic and start array tokens
                        case LexerTokenKind.OpenGenerics:
                        case LexerTokenKind.OpenArrayDimension:
                            throw new NotImplementedException();


                        default:
                            return CreateQualifiedType();
                    }
                }
            }

            ParseResult<ITypeIdentifier> CreateQualifiedType()
            {
                if (identifiersList.Count == 0)
                {
                    throw new NotImplementedException();
                }

                var identifiers = identifiersList.Select(i =>
                        new Identifier(i.Memory.ToString())
                    ).ToList();

                QualifiedTypeIdentifier typeIdentifier;
                if (isRootedType)
                {
                    typeIdentifier = QualifiedTypeIdentifier.BuildRootedFromIdentifierList(identifiers);
                }
                else
                {
                    typeIdentifier = QualifiedTypeIdentifier.BuildFromIdentifierList(identifiers);
                }

                return new ParseResult<ITypeIdentifier>(typeIdentifier);
            }
        }

        public async Task<ParseResult<ITypeName>> ParseTypeName(IParserContext context)
        {
            var result = await context.Lexer.TryGetIdentifierToken();

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var identifierToken = result.Token;

            var identifier = new Identifier(identifierToken.Memory.ToString());

            ITypeName value = new SimpleTypeName(identifier);

            return new ParseResult<ITypeName>(value);
        }
    }
}
