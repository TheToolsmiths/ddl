using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ddl.Common;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Parser.Ast.Models.Arrays;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Identifiers;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.TypePaths.Identifiers;
using TheToolsmiths.Ddl.Parser.Contexts;
using TheToolsmiths.Ddl.Parser.Models.Identifiers;

namespace TheToolsmiths.Ddl.Parser.Common
{
    public class TypeIdentifierParser
    {
        public async Task<Result<ITypeIdentifier>> Parse(IParserContext context)
        {
            var identifiersList = new List<TypeIdentifierPathPart>();

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
                LexerToken nameToken;
                {
                    var result = await context.Lexer.TryGetIdentifierToken();

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    nameToken = result.Token;
                }

                Identifier name = new Identifier(nameToken.Memory.ToString());

                TypeIdentifierPathPart pathPart;
                if (await context.Lexer.IsNextOpenGenericsToken())
                {
                    var result = await this.ParseGenericPathPart(context, name);

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    pathPart = result.Value;
                }
                else
                {
                    pathPart = new SimpleIdentifierPathPart(name);
                }

                identifiersList.Add(pathPart);

                if (await context.Lexer.TryConsumeNamespaceSeparatorToken() == false)
                {
                    break;
                }
            }

            QualifiedTypeIdentifier genericIdentifier;
            {
                genericIdentifier = isRootedType
                    ? QualifiedTypeIdentifierBuilder.BuildRootedFromParts(identifiersList)
                    : QualifiedTypeIdentifierBuilder.BuildFromParts(identifiersList);
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

        private async Task<Result<Stack<ModifierTypeKind>>> ParseTypeModifiers(IParserContext context)
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

            return Result.FromValue(modifiers);
        }

        private async Task<Result<GenericIdentifierPathPart>> ParseGenericPathPart(IParserContext context, Identifier name)
        {
            if (await context.Lexer.TryConsumeOpenGenericsToken() == false)
            {
                throw new NotImplementedException();
            }

            var parameters = new List<ITypeIdentifier>();

            bool isParameterListCompleted = false;
            while (isParameterListCompleted == false)
            {
                var parseResult = await context.Parsers.ParseTypeIdentifier().ConfigureAwait(false);

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
                        context.Lexer.PopToken();
                        isParameterListCompleted = true;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            if (parameters.Count == 0)
            {
                throw new NotImplementedException();
            }

            var pathPart = new GenericIdentifierPathPart(name, parameters);

            return Result.FromValue(pathPart);
        }

        private async Task<Result<ITypeIdentifier>> ParseArrayType(
            IParserContext context,
            QualifiedTypeIdentifier typeIdentifier)
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

                var size = dimensions.Count == 0 ? (ArraySize)new DynamicArraySize() : new FixedArraySize(dimensions);
                sizes.Add(size);
            }

            var arrayTypeIdentifier = new ArrayTypeIdentifier(typeIdentifier, sizes);

            return Result.FromValue<ITypeIdentifier>(arrayTypeIdentifier);
        }

        private Result<ITypeIdentifier> CreateReferenceType(
            ITypeIdentifier typeIdentifier,
            ReferenceTypeKind? referenceKind)
        {
            if (referenceKind != null)
            {
                typeIdentifier = new ReferenceTypeIdentifier(typeIdentifier, referenceKind.Value);
            }

            return Result.FromValue(typeIdentifier);
        }

        private Result<ITypeIdentifier> CreateModifiersType(
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

            return Result.FromValue(typeIdentifier);
        }
    }
}
