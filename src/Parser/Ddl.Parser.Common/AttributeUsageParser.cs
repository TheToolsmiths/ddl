using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ddl.Common;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Parser.Contexts;
using TheToolsmiths.Ddl.Parser.Models.AttributeUsage;
using TheToolsmiths.Ddl.Parser.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Parser.Models.Identifiers;
using TheToolsmiths.Ddl.Parser.Models.Types;
using TheToolsmiths.Ddl.Parser.Models.Types.Identifiers;
using TheToolsmiths.Ddl.Parser.Models.Values;

namespace TheToolsmiths.Ddl.Parser.Common
{
    public class AttributeUsageParser
    {
        public async Task<Result<IReadOnlyList<IAttributeUse>>> ParseAttributeUseList(IParserContext context)
        {
            var attributeUses = new List<IAttributeUse>();

            while (true)
            {
                // If next token isn't open attribute
                if (await context.Lexer.IsNextOpenAttributeToken() == false)
                {
                    break;
                }

                var result = await this.ParseAttributeUseBlock(context);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                attributeUses.AddRange(result.Value);
            }

            return Result.FromValue<IReadOnlyList<IAttributeUse>>(attributeUses);
        }

        private async Task<Result<IReadOnlyList<IAttributeUse>>> ParseAttributeUseBlock(IParserContext context)
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

            return Result.FromValue<IReadOnlyList<IAttributeUse>>(attributeUses);
        }

        private async Task<Result<IAttributeUse>> ParseAttributeUse(IParserContext context)
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

                return await this.ParseAttributeWithTypedStructuredInitialization(context);
            }

            throw new NotImplementedException();
        }

        private async Task<Result<IAttributeUse>> ParseAttributeWithTypedConditionalExpression(
            IParserContext context)
        {
            ITypeIdentifier typeIdentifier;
            {
                var result = await context.Parsers.ParseTypeIdentifier();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                typeIdentifier = result.Value;
            }

            ConditionalExpression conditionalExpression;
            {
                var result = await context.Parsers.ParseConditionalExpressionRoot();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                conditionalExpression = result.Value;
            }

            var value = new ConditionalAttributeUse(typeIdentifier, conditionalExpression);
            return Result.FromValue<IAttributeUse>(value);
        }

        private async Task<Result<IAttributeUse>> ParseAttributeWithTypedStructuredInitialization(IParserContext context)
        {
            ITypeIdentifier identifier;
            {
                var result = await context.Parsers.ParseTypeIdentifier();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                identifier = result.Value;
            }

            if (await context.Lexer.IsNextOpenParenthesesToken())
            {
                var result = await context.Parsers.ParseConditionalExpressionRoot();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var conditionalExpression = result.Value;

                var value = new ConditionalAttributeUse(identifier, conditionalExpression);

                return Result.FromValue<IAttributeUse>(value);
            }

            {
                StructValueInitialization initialization;

                if (await context.Lexer.IsNextOpenScopeToken() == false)
                {
                    initialization = StructValueInitialization.CreateEmpty();
                }
                else
                {
                    var result = await context.Parsers.ParseStructValueInitialization();

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    initialization = result.Value;
                }

                var value = new TypedStructInitializationUse(identifier, initialization);

                return Result.FromValue<IAttributeUse>(value);
            }
        }

        private async Task<Result<IAttributeUse>> ParseKeyedAttributeUse(IParserContext context)
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
                    ITypeIdentifier identifier;
                    {
                        var result = await context.Parsers.ParseTypeIdentifier();

                        if (result.IsError)
                        {
                            throw new NotImplementedException();
                        }

                        identifier = result.Value;
                    }

                    StructValueInitialization structInitialization;
                    {
                        if (await context.Lexer.IsNextOpenScopeToken() == false)
                        {
                            structInitialization = StructValueInitialization.CreateEmpty();
                        }
                        else
                        {
                            var result = await context.Parsers.ParseStructValueInitialization();

                            if (result.IsError)
                            {
                                throw new NotImplementedException();
                            }

                            structInitialization = result.Value;
                        }
                    }

                    var initialization = new TypedStructValueInitialization(identifier, structInitialization);

                    var value = new KeyedTypedAttributeUse(key, initialization);

                    return Result.FromValue<IAttributeUse>(value);
                }

                if (token.IsLiteral())
                {
                    var result = await context.Parsers.ParseLiteralValue();

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    var initialization = result.Value;

                    var value = new KeyedLiteralAttributeUse(key, initialization);

                    return Result.FromValue<IAttributeUse>(value);
                }

                if (token.IsOpenScope())
                {
                    var result = await context.Parsers.ParseStructValueInitialization();

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    var initialization = result.Value;

                    var value = new KeyedStructInitializationAttributeUse(key, initialization);

                    return Result.FromValue<IAttributeUse>(value);
                }
            }

            throw new NotImplementedException();
        }
    }
}
