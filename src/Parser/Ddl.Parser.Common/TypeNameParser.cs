using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Parser.Contexts;
using TheToolsmiths.Ddl.Parser.Models.Identifiers;
using TheToolsmiths.Ddl.Parser.Models.Types;

namespace TheToolsmiths.Ddl.Parser.Common
{
    public class TypeNameParser
    {
        public async Task<ParseResult<ITypeName>> ParseTypeName(IParserContext context)
        {
            Identifier identifier;
            {
                var result = await context.Lexer.TryGetIdentifierToken();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var identifierToken = result.Token;

                identifier = new Identifier(identifierToken.Memory.ToString());
            }

            {
                var result = await context.Lexer.TryPeekOpenGenericsToken();

                if (result.HasToken)
                {
                    return await this.ParseGenericType(context, identifier);
                }

                return this.CreateSimpleType(identifier);
            }
        }

        private ParseResult<ITypeName> CreateSimpleType(Identifier identifier)
        {
            ITypeName value = new SimpleTypeName(identifier);

            return new ParseResult<ITypeName>(value);
        }

        private async Task<ParseResult<ITypeName>> ParseGenericType(IParserContext context, Identifier identifier)
        {
            if (await context.Lexer.TryConsumeOpenGenericsToken() == false)
            {
                throw new NotImplementedException();
            }

            var argumentList = new List<Identifier>();

            while (true)
            {
                var result = await context.Lexer.TryGetIdentifierToken();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var argIdentifier = Identifier.FromString(result.Token.Memory.ToString());

                argumentList.Add(argIdentifier);

                if (await context.Lexer.TryConsumeListSeparatorToken() == false)
                {
                    break;
                }
            }

            if (await context.Lexer.TryConsumeCloseGenericsToken() == false)
            {
                throw new NotImplementedException();
            }

            var typeName = new GenericTypeName(identifier, argumentList);

            return new ParseResult<ITypeName>(typeName);
        }
    }
}
