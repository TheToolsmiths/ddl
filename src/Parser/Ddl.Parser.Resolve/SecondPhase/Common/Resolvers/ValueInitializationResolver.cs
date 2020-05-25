using System;

using Ddl.Common;

using TheToolsmiths.Ddl.Parser.Models.Values;

using EmptyValueInitialization = TheToolsmiths.Ddl.Parser.Ast.Models.Values.EmptyValueInitialization;
using LiteralValueInitialization = TheToolsmiths.Ddl.Parser.Ast.Models.Values.LiteralValueInitialization;
using StructValueInitialization = TheToolsmiths.Ddl.Parser.Ast.Models.Values.StructValueInitialization;
using TypeIdentifierInitialization = TheToolsmiths.Ddl.Parser.Ast.Models.Values.TypeIdentifierInitialization;

namespace TheToolsmiths.Ddl.Resolve.SecondPhase.Common.Resolvers
{
    public class ValueInitializationResolver
    {
        public Result<ValueInitialization> Resolve(
            ScopeItemResolveContext context,
            Parser.Ast.Models.Values.ValueInitialization astInitialization)
        {
            return astInitialization switch
            {
                EmptyValueInitialization initialization => this.ResolveEmptyValue(context, initialization),
                LiteralValueInitialization initialization => this.ResolveLiteralValue(context, initialization),
                StructValueInitialization initialization => this.ResolveStructValue(context, initialization),
                TypeIdentifierInitialization initialization => this.ResolveTypeIdentifier(context, initialization),
                _ => throw new ArgumentOutOfRangeException(nameof(astInitialization))
            };
        }

        private Result<ValueInitialization> ResolveTypeIdentifier(
            ScopeItemResolveContext context,
            TypeIdentifierInitialization initialization)
        {
            throw new NotImplementedException();
        }

        private Result<ValueInitialization> ResolveStructValue(
            ScopeItemResolveContext context,
            StructValueInitialization initialization)
        {
            throw new NotImplementedException();
        }

        private Result<ValueInitialization> ResolveEmptyValue(
            ScopeItemResolveContext context,
            EmptyValueInitialization initialization)
        {
            return Result.FromValue<ValueInitialization>(new Parser.Models.Values.EmptyValueInitialization());
        }

        private Result<ValueInitialization> ResolveLiteralValue(
            ScopeItemResolveContext context,
            LiteralValueInitialization initialization)
        {
            throw new NotImplementedException();
        }
    }
}
