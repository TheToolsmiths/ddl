using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Models.AttributeUsage;
using TheToolsmiths.Ddl.Models.Identifiers;
using TheToolsmiths.Ddl.Parser.Contexts;

namespace TheToolsmiths.Ddl.Parser.Parsers.Implementations
{
    internal class AttributeUsageParser
    {
        public async Task<ParseResult<IReadOnlyList<IAttributeUse>>> ParseAttributeUseList(IParserContext context)
        {
            var attributeUses = new List<IAttributeUse>();

            while (true)
            {
                {
                    var result = await this.ParseAttributeUseBlock(context);

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    attributeUses.AddRange(result.Value);
                }

                // If next token isn't open attribute
                {
                    if (await context.Lexer.IsNextOpenAttributeToken() == false)
                    {
                        break;
                    }
                }
            }

            return new ParseResult<IReadOnlyList<IAttributeUse>>(attributeUses);
        }

        private async Task<ParseResult<IReadOnlyList<IAttributeUse>>> ParseAttributeUseBlock(IParserContext context)
        {
            var attributeUses = new List<IAttributeUse>();

            // Make sure we're parsing an attribute use list
            {
                if (await context.Lexer.TryConsumeOpenAttributeToken() == false)
                {
                    throw new NotImplementedException();
                }
            }

            while (true)
            {
                {
                    var result = await this.ParseAttributeUse(context);

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    attributeUses.Add(result.Value);
                }

                // If next token isn't close attribute
                {
                    var result = await context.Lexer.TryPeekToken();

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    var token = result.Token;

                    if (token.IsListSeparator())
                    {
                        context.Lexer.PopToken();
                        continue;
                    }

                    break;
                }
            }

            // Make sure we're parsing an attribute use list
            {
                if (await context.Lexer.TryConsumeCloseAttributeToken() == false)
                {
                    throw new NotImplementedException();
                }
            }

            return new ParseResult<IReadOnlyList<IAttributeUse>>(attributeUses);
        }

        private async Task<ParseResult<IAttributeUse>> ParseAttributeUse(IParserContext context)
        {
            var result = await context.Lexer.TryPeekNextTwoToken();

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var firstToken = result.FirstToken;

            var secondToken = result.SecondToken;

            if (firstToken.IsNamespaceSeparator())
            {
                return await this.ParseAttributeWithTypedStructuredInitialization(context);
            }

            if (firstToken.IsIdentifier())
            {
                if (secondToken.IsFieldInitialization())
                {
                    return await this.ParseKeyedAttributeUse(context);
                }

                if (secondToken.IsNamespaceSeparator()
                    || secondToken.IsOpenScope())
                {
                    return await this.ParseAttributeWithTypedStructuredInitialization(context);
                }

                return await this.ParseAttributeWithTypedStructuredInitialization(context);
            }

            throw new NotImplementedException();
        }
        private async Task<ParseResult<IAttributeUse>> ParseAttributeUseOld(IParserContext context)
        {
            throw new NotImplementedException();

            //Identifier identifier;
            //{
            //    var result = await context.Lexer.TryPeekNextTwoToken();

            //    if (result.IsError)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    //var token = result.Token;

            //    //if (token.Kind == LexerTokenKind.NamespaceSeparator)
            //    //{
            //    //    return await this.ParseAttributeWithStructuredInitialization(context);
            //    //}

            //    //if (token.Kind != LexerTokenKind.Identifier)
            //    //{
            //    //    throw new NotImplementedException();
            //    //}

            //    //identifier = Identifier.FromString(token.Memory.ToString());

            //    //context.Lexer.PopToken();
            //}

            //{
            //    var result = await context.Lexer.TryPeekToken();

            //    if (result.IsError)
            //    {
            //        throw new NotImplementedException();
            //    }

            //    var token = result.Token;

            //    // If theres an assigment its because its a keyed attribute use
            //    if (token.Kind == LexerTokenKind.ValueAssignment)
            //    {
            //        context.Lexer.PopToken();

            //        return await this.ParseKeyedAttributeUse(context);
            //    }

            //    if (token.Kind == LexerTokenKind.OpenScope)
            //    {
            //        return await this.ParseAttributeWithStructuredInitialization(context);
            //    }

            //    if (token.Kind == LexerTokenKind.NamespaceSeparator)
            //    {
            //        return await this.ParseAttributeWithTypedStructuredInitialization(context, identifier);
            //    }

            //    if (token.Kind == LexerTokenKind.OpenGenerics)
            //    {
            //        return await this.ParseAttributeWithGenericType(context);
            //    }
            //}

            //{
            //    var type = new QualifiedTypeIdentifier(new SimpleTypeName(identifier));
            //    var value = new TypedStructInitializationUse(type, StructValueInitialization.CreateEmpty());

            //    return new ParseResult<IAttributeUse>(value);
            //}
        }

        private async Task<ParseResult<IAttributeUse>> ParseAttributeWithTypedStructuredInitialization(IParserContext context)
        {
            var result = await context.Parsers.ParseTypedStructValueInitialization(context);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var initialization = result.Value;

            var value = new TypedStructInitializationUse(initialization.Type, initialization.Initialization);

            return new ParseResult<IAttributeUse>(value);
        }

        private async Task<ParseResult<IAttributeUse>> ParseAttributeWithStructuredInitialization(IParserContext context)
        {
            var result = await context.Parsers.ParseTypedStructValueInitialization(context);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var initialization = result.Value;

            var value = new TypedStructInitializationUse(initialization.Type, initialization.Initialization);

            return new ParseResult<IAttributeUse>(value);
        }

        private async Task<ParseResult<IAttributeUse>> ParseKeyedAttributeUse(IParserContext context)
        {

            Identifier key;
            {
                var result = await context.Lexer.TryGetIdentifierToken();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var token = result.Token;

                key = Identifier.FromString(token.Memory.ToString());
            }

            {
                if (await context.Lexer.TryConsumeFieldInitializationToken() == false)
                {
                    throw new NotImplementedException();
                }
            }

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

                if (token.IsIdentifier()
                    || token.IsNamespaceSeparator())
                {
                    var result = await context.Parsers.ParseTypedStructValueInitialization(context);

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    var initialization = result.Value;

                    var value = new KeyedTypedAttributeUse(key, initialization);

                    return new ParseResult<IAttributeUse>(value);
                }

                if (token.IsLiteral())
                {
                    var result = await context.Parsers.ParseLiteralValue(context);

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    var initialization = result.Value;

                    var value = new KeyedLiteralAttributeUse(key, initialization);

                    return new ParseResult<IAttributeUse>(value);
                }

                if (token.IsOpenScope())
                {
                    var result = await context.Parsers.ParseStructValueInitialization(context);

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    var initialization = result.Value;

                    var value = new KeyedStructInitializationAttributeUse(key, initialization);

                    return new ParseResult<IAttributeUse>(value);
                }
            }

            throw new NotImplementedException();
        }
    }
}
