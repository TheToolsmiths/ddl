using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Models.Arrays;
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

            Stack<ModifierTypeKind> modifiers;
            {
                var parseResult = await this.ParseTypeModifiers(context);

                if (parseResult.IsError)
                {
                    throw new NotImplementedException();
                }

                modifiers = parseResult.Value;
            }

            ReferenceTypeKind? referenceKind = null;
            {
                var result = await context.Lexer.TryPeekIdentifierToken();

                if (result.HasToken)
                {
                    var token = result.Token;

                    if (token.Memory.Span.SequenceEqual(ParserIdentifierConstants.Reference))
                    {
                        context.Lexer.PopToken();

                        referenceKind = ReferenceTypeKind.Reference;
                    }
                    else if (token.Memory.Span.SequenceEqual(ParserIdentifierConstants.Handle))
                    {
                        context.Lexer.PopToken();

                        referenceKind = ReferenceTypeKind.Handle;
                    }
                    else if (token.Memory.Span.SequenceEqual(ParserIdentifierConstants.Owns))
                    {
                        context.Lexer.PopToken();

                        referenceKind = ReferenceTypeKind.Owns;
                    }
                }
            }

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
                var result = await context.Lexer.TryGetIdentifierToken();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var identifierToken = result.Token;

                identifiersList.Add(identifierToken);

                if (await context.Lexer.TryConsumeNamespaceSeparatorToken() == false)
                {
                    break;
                }
            }

            IQualifiedTypeIdentifier genericIdentifier;
            {
                var result = await context.Lexer.TryPeekOpenGenericsToken();

                ParseResult<IQualifiedTypeIdentifier> parseResult;
                if (result.HasToken)
                {
                    parseResult = await this.ParseGenericType(context, identifiersList, isRootedType);
                }
                else
                {
                    parseResult = this.CreateQualifiedType(identifiersList, isRootedType);
                }

                if (parseResult.IsError)
                {
                    throw new NotImplementedException();
                }

                genericIdentifier = parseResult.Value;
            }

            ITypeIdentifier arrayTypeIdentifier;
            {
                var result = await context.Lexer.TryPeekOpenAttributeToken();

                if (result.HasToken)
                {
                    var parseResult = await this.ParseArrayType(context, genericIdentifier);

                    if (parseResult.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    arrayTypeIdentifier = parseResult.Value;
                }
                else
                {
                    arrayTypeIdentifier = genericIdentifier;
                }
            }

            ITypeIdentifier referenceIdentifier;
            {
                var parseResult = this.CreateReferenceType(arrayTypeIdentifier, referenceKind);

                if (parseResult.IsError)
                {
                    throw new NotImplementedException();
                }

                referenceIdentifier = parseResult.Value;
            }

            return this.CreateModifiersType(referenceIdentifier, modifiers);
        }

        private async Task<ParseResult<Stack<ModifierTypeKind>>> ParseTypeModifiers(IParserContext context)
        {

            var modifiers = new Stack<ModifierTypeKind>();

            while (true)
            {
                var result = await context.Lexer.TryPeekIdentifierToken();

                if (result.IsError)
                {
                    break;
                }

                var token = result.Token;

                if (token.Memory.Span.SequenceEqual(ParserIdentifierConstants.Constant))
                {
                    context.Lexer.PopToken();

                    modifiers.Push(ModifierTypeKind.Constant);
                }
                else
                {
                    break;
                }
            }

            return new ParseResult<Stack<ModifierTypeKind>>(modifiers);
        }

        private async Task<ParseResult<IQualifiedTypeIdentifier>> ParseGenericType(
            IParserContext context,
            IReadOnlyList<LexerToken> identifiersList,
            bool isRootedType)
        {
            if (await context.Lexer.TryConsumeOpenGenericsToken() == false)
            {
                throw new NotImplementedException();
            }

            var parameters = new List<ITypeIdentifier>();

            await ParseGenericParametersList();

            async Task ParseGenericParametersList()
            {
                while (true)
                {
                    var parseResult = await context.Parsers.ParseTypeIdentifier(context);

                    if (parseResult.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    parameters.Add(parseResult.Value);

                    var result = await context.Lexer.TryPeekToken();

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    var token = result.Token;

                    switch (token.Kind)
                    {
                        case LexerTokenKind.ListSeparator:
                            context.Lexer.PopToken();
                            continue;
                        case LexerTokenKind.CloseGenerics:
                            return;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }

            if (await context.Lexer.TryConsumeCloseGenericsToken() == false)
            {
                throw new NotImplementedException();
            }

            if (identifiersList.Count == 0)
            {
                throw new NotImplementedException();
            }

            var identifiers = identifiersList.Select(i =>
                new Identifier(i.Memory.ToString())
            ).ToList();

            var genericTypeIdentifier = isRootedType
                ? GenericTypeIdentifier.BuildRootedFromIdentifierList(identifiers, parameters)
                : GenericTypeIdentifier.BuildFromIdentifierList(identifiers, parameters);

            return new ParseResult<IQualifiedTypeIdentifier>(genericTypeIdentifier);
        }

        private async Task<ParseResult<ITypeIdentifier>> ParseArrayType(IParserContext context, IQualifiedTypeIdentifier typeIdentifier)
        {
            var sizes = new List<ArraySize>();

            while (await context.Lexer.IsNextOpenAttributeToken())
            {
                await ParseGenericParametersList();
            }

            async Task ParseGenericParametersList()
            {
                if (await context.Lexer.TryConsumeOpenAttributeToken() == false)
                {
                    throw new NotImplementedException();
                }

                var literals = new List<LexerToken>();

                while (true)
                {
                    var result = await context.Lexer.TryPeekNumberToken();

                    if (result.IsError)
                    {
                        break;
                    }

                    literals.Add(result.Token);

                    context.Lexer.PopToken();

                    if (await context.Lexer.TryConsumeListSeparatorToken() == false)
                    {
                        break;
                    }
                }

                if (await context.Lexer.TryConsumeCloseAttributeToken() == false)
                {
                    throw new NotImplementedException();
                }

                var dimensions = literals.Select(lt => lt.Memory.ToString()).ToList();

                var size = dimensions.Count == 0
                    ? (ArraySize)new DynamicArraySize()
                    : new FixedArraySize(dimensions);
                sizes.Add(size);
            }

            var arrayTypeIdentifier = new ArrayTypeIdentifier(typeIdentifier, sizes);

            return new ParseResult<ITypeIdentifier>(arrayTypeIdentifier);
        }

        private ParseResult<IQualifiedTypeIdentifier> CreateQualifiedType(List<LexerToken> identifiersList,
            bool isRootedType)
        {
            if (identifiersList.Count == 0)
            {
                throw new NotImplementedException();
            }

            var identifiers = identifiersList.Select(i =>
                    new Identifier(i.Memory.ToString())
                ).ToList();

            var typeIdentifier = isRootedType
                ? SimpleTypeIdentifier.BuildRootedFromIdentifierList(identifiers)
                : SimpleTypeIdentifier.BuildFromIdentifierList(identifiers);

            return new ParseResult<IQualifiedTypeIdentifier>(typeIdentifier);
        }

        ParseResult<ITypeIdentifier> CreateReferenceType(ITypeIdentifier typeIdentifier, ReferenceTypeKind? referenceKind)
        {
            if (referenceKind != null)
            {
                typeIdentifier = new ReferenceTypeIdentifier(typeIdentifier, referenceKind.Value);
            }

            return new ParseResult<ITypeIdentifier>(typeIdentifier);
        }

        private ParseResult<ITypeIdentifier> CreateModifiersType(
            ITypeIdentifier typeIdentifier,
            Stack<ModifierTypeKind> modifiers)
        {
            while (modifiers.TryPop(out var modifierKind))
            {
                typeIdentifier = modifierKind switch
                {
                    ModifierTypeKind.Constant => new ConstantTypeIdentifier(typeIdentifier),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }

            return new ParseResult<ITypeIdentifier>(typeIdentifier);
        }
    }
}
