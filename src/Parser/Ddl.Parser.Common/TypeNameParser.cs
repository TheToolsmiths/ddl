using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheToolsmiths.Ddl.Lexer;
using TheToolsmiths.Ddl.Parser.Ast.Models.Identifiers;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Names;
using TheToolsmiths.Ddl.Parser.Contexts;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Common
{
    public class TypeNameParser
    {
        public async Task<Result<TypeName>> ParseTypeName(IParserContext context)
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

        private Result<TypeName> CreateSimpleType(Identifier identifier)
        {
            TypeName value = new SimpleTypeName(identifier);

            return Result.FromValue(value);
        }

        private async Task<Result<TypeName>> ParseGenericType(IParserContext context, Identifier identifier)
        {
            if (await context.Lexer.TryConsumeOpenGenericsToken() == false)
            {
                throw new NotImplementedException();
            }

            var parameters = new List<Identifier>();

            while (true)
            {
                var result = await context.Lexer.TryGetIdentifierToken();

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                var argIdentifier = Identifier.FromString(result.Token.Memory.ToString());

                parameters.Add(argIdentifier);

                if (await context.Lexer.TryConsumeListSeparatorToken() == false)
                {
                    break;
                }
            }

            if (await context.Lexer.TryConsumeCloseGenericsToken() == false)
            {
                throw new NotImplementedException();
            }

            var typeName = new GenericTypeName(identifier, parameters);

            return Result.FromValue<TypeName>(typeName);
        }
    }
}
