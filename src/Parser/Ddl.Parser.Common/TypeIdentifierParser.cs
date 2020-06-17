using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Parser.Ast.Models.Arrays;
using TheToolsmiths.Ddl.Parser.Ast.Models.Identifiers;
using TheToolsmiths.Ddl.Parser.Ast.Models.Literals;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Identifiers;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.TypePaths.Identifiers;
using TheToolsmiths.Ddl.Parser.Contexts;

namespace TheToolsmiths.Ddl.Parser.Common
{
    public class TypeIdentifierParser
    {
        public async Task<Result<ITypeIdentifier>> Parse(IParserContext context)
        {
            if (await context.Lexer.IsNextNamespaceSeparatorToken())
            {
                return (await this.ParseArrayOrQualifiedTypeIdentifier(context)).As<ITypeIdentifier>();
            }

            var result = await context.Lexer.TryPeekIdentifierToken();

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var token = result.Token;

            if (token.Memory.Span.SequenceEqual(ParserIdentifierConstants.Constant))
            {
                return (await this.ParseConstantTypeIdentifier(context)).As<ITypeIdentifier>();
            }

            return (await this.ParseModifiableTypeIdentifier(context)).As<ITypeIdentifier>();
        }

        public async Task<Result<IGenericParameterTypeIdentifier>> ParseGenericParameterTypeIdentifier(
            IParserContext context)
        {
            return (await this.ParseArrayOrQualifiedTypeIdentifier(context)).As<IGenericParameterTypeIdentifier>();
        }

        private async Task<Result<IModifiableTypeIdentifier>> ParseModifiableTypeIdentifier(IParserContext context)
        {
            var result = await context.Lexer.TryPeekIdentifierToken();

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var token = result.Token;

            if (token.Memory.Span.SequenceEqual(ParserIdentifierConstants.Reference) ||
                token.Memory.Span.SequenceEqual(ParserIdentifierConstants.Handle) ||
                token.Memory.Span.SequenceEqual(ParserIdentifierConstants.Owns))
            {
                return (await this.ParseReferenceTypeIdentifier(context)).As<IModifiableTypeIdentifier>();
            }

            return (await this.ParseArrayOrQualifiedTypeIdentifier(context)).As<IModifiableTypeIdentifier>();
        }

        private async Task<Result<IReferenceableTypeIdentifier>> ParseArrayOrQualifiedTypeIdentifier(
            IParserContext context)
        {
            var result = await this.ParseQualifiedTypeIdentifier(context);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var qualifiedType = result.Value;

            if (await context.Lexer.IsNextOpenAttributeToken())
            {
                return (await this.ParseArrayType(context, qualifiedType)).As<IReferenceableTypeIdentifier>();
            }

            return Result.FromValue<IReferenceableTypeIdentifier>(qualifiedType);
        }

        private async Task<Result<QualifiedTypeIdentifier>> ParseQualifiedTypeIdentifier(IParserContext context)
        {
            var identifiersList = new List<TypeIdentifierPathPart>();

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

            var genericIdentifier = isRootedType
                ? QualifiedTypeIdentifierBuilder.BuildRootedFromParts(identifiersList)
                : QualifiedTypeIdentifierBuilder.BuildFromParts(identifiersList);

            return Result.FromValue(genericIdentifier);
        }

        private async Task<Result<ReferenceTypeIdentifier>> ParseReferenceTypeIdentifier(IParserContext context)
        {
            ReferenceKind referenceKind;
            {
                var result = await context.Lexer.TryGetIdentifierToken();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var token = result.Token;

                if (token.Memory.Span.SequenceEqual(ParserIdentifierConstants.Reference))
                {
                    referenceKind = ReferenceKind.Reference;
                }
                else if (token.Memory.Span.SequenceEqual(ParserIdentifierConstants.Handle))
                {
                    referenceKind = ReferenceKind.Handle;
                }
                else if (token.Memory.Span.SequenceEqual(ParserIdentifierConstants.Owns))
                {
                    referenceKind = ReferenceKind.Owns;
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            IReferenceableTypeIdentifier typeIdentifier;
            {
                var result = await this.ParseArrayOrQualifiedTypeIdentifier(context);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                typeIdentifier = result.Value;
            }

            var referenceType = new ReferenceTypeIdentifier(typeIdentifier, referenceKind);

            return Result.FromValue(referenceType);
        }

        private async Task<Result<ITypeIdentifier>> ParseConstantTypeIdentifier(IParserContext context)
        {
            LexerToken token;
            {
                var result = await context.Lexer.TryGetIdentifierToken();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                token = result.Token;
            }

            if (token.Memory.Span.SequenceEqual(ParserIdentifierConstants.Constant))
            {
                IModifiableTypeIdentifier typeIdentifier;
                {
                    var result = await this.ParseModifiableTypeIdentifier(context);

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    typeIdentifier = result.Value;
                }

                return Result.FromValue<ITypeIdentifier>(new ConstantTypeIdentifier(typeIdentifier));
            }

            throw new NotImplementedException();
        }

        private async Task<Result<GenericIdentifierPathPart>> ParseGenericPathPart(
            IParserContext context,
            Identifier name)
        {
            if (await context.Lexer.TryConsumeOpenGenericsToken() == false)
            {
                throw new NotImplementedException();
            }

            var parameters = new List<IGenericParameterTypeIdentifier>();

            bool isParameterListCompleted = false;
            while (isParameterListCompleted == false)
            {
                var parseResult = await context.Parsers.ParseGenericParameterTypeIdentifier().ConfigureAwait(false);

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

        private async Task<Result<ArrayTypeIdentifier>> ParseArrayType(
            IParserContext context,
            QualifiedTypeIdentifier typeIdentifier)
        {
            var sizes = new List<ArraySize>();

            while (await context.Lexer.IsNextOpenAttributeToken())
            {
                await ParseArraySizeList();
            }

            async Task ParseArraySizeList()
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

                var dimensions = literals.Select(lt => new NumberLiteral(lt.Memory.ToString())).ToList();

                var size = dimensions.Count == 0 ? (ArraySize)new DynamicArraySize() : new FixedArraySize(dimensions);
                sizes.Add(size);
            }

            var arrayTypeIdentifier = new ArrayTypeIdentifier(typeIdentifier, sizes);

            return Result.FromValue(arrayTypeIdentifier);
        }
    }
}
