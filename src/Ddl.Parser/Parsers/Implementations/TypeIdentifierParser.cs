using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Models.Identifiers;
using TheToolsmiths.Ddl.Models.Types;
using TheToolsmiths.Ddl.Parser.Lexers;

namespace TheToolsmiths.Ddl.Parser.Parsers.Implementations
{
    internal class TypeIdentifierParser
    {
        public async Task<ParseResult<ITypeIdentifier>> Parse(IParserContext context)
        {
            var identifiersList = new List<LexerToken>();

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
                        case LexerTokenKind.ListSeparator:
                        case LexerTokenKind.CloseScope:
                            return CreateQualifiedType();

                        case LexerTokenKind.NamespaceSeparator:
                            context.Lexer.PopToken();
                            break;

                        // TODO: Add Support for generic and start array tokens

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }

            ParseResult<ITypeIdentifier> CreateQualifiedType()
            {
                var typeIdentifier = QualifiedTypeIdentifier.BuildFromIdentifierList(
                    identifiersList.Select(i =>
                        new Identifier(i.Memory.ToString())
                    ).ToList()
                );

                return new ParseResult<ITypeIdentifier>(typeIdentifier);
            }
        }
    }
}
