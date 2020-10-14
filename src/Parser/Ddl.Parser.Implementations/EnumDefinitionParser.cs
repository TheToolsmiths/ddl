﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Models.Ast.Enums;
using TheToolsmiths.Ddl.Models.Ast.Identifiers;
using TheToolsmiths.Ddl.Models.Ast.Literals;
using TheToolsmiths.Ddl.Models.Ast.Types.Names;
using TheToolsmiths.Ddl.Parser.Contexts;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Implementations
{
    internal class EnumDefinitionParser : IRootItemParser
    {
        public async ValueTask<RootItemParseResult> ParseRootContent(IRootItemParserContext context)
        {
            TypeName typeName;
            {
                var result = await context.Parsers.ParseTypeName();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                typeName = result.Value;
            }

            if (await context.Lexer.TryConsumeOpenScopeToken() == false)
            {
                throw new NotImplementedException();
            }

            EnumDefinitionContent content;
            {
                var parseResult = await this.ParseBlockContent(context);

                if (parseResult.IsError)
                {
                    throw new NotImplementedException();
                }

                content = parseResult.Value;
            }

            if (await context.Lexer.TryConsumeCloseScopeToken() == false)
            {
                throw new NotImplementedException();
            }

            var value = new EnumAstDefinition(typeName, content, context.AttributeList);

            return RootItemParseResult.FromResult(value);
        }

        private async Task<Result<EnumDefinitionContent>> ParseBlockContent(IRootItemParserContext context)
        {
            var items = new List<IEnumDefinitionItem>();

            while (true)
            {
                if (await context.Lexer.IsNextCloseScopeToken())
                {
                    break;
                }

                await ParseEnumDefinition();

                if (await context.Lexer.TryConsumeListSeparatorToken())
                {
                    continue;
                }

                if (await context.Lexer.IsNextCloseScopeToken())
                {
                    break;
                }

                throw new NotImplementedException();
            }

            var value = new EnumDefinitionContent(items);

            return Result.FromValue(value);

            async Task ParseEnumDefinition()
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

                var identifier = new Identifier(token.Memory.ToString());

                LiteralValue literalValue;
                if (await context.Lexer.TryConsumeFieldInitializationToken())
                {
                    var parseResult = await context.Parsers.ParseLiteralValue();

                    if (parseResult.IsError)
                    {
                        throw new NotImplementedException();
                    }

                    literalValue = parseResult.Value;
                }
                else
                {
                    literalValue = new DefaultLiteral();
                }

                var item = new EnumDefinitionConstantDefinition(identifier, literalValue);

                items.Add(item);
            }
        }
    }
}
