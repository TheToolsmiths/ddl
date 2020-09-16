using System;

using TheToolsmiths.Ddl.Models.Values;
using TheToolsmiths.Ddl.Parser.TypeResolver.Contexts;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.Common
{
    public class ValueInitializationTypeResolver
    {
        public Result<ValueInitialization> Resolve(IRootScopeTypeResolveContext context, ValueInitialization initialization)
        {
            return initialization switch
            {
                EmptyInitialization _ => this.PassthroughResolve(context, initialization),
                LiteralInitialization _ => this.PassthroughResolve(context, initialization),
                StructInitialization _ => this.PassthroughResolve(context, initialization),
                TypedStructInitialization typedStructInitialization => this.ResolveTypedInitialization(context, typedStructInitialization),
                _ => throw new ArgumentOutOfRangeException(nameof(initialization))
            };
        }

        private Result<ValueInitialization> ResolveTypedInitialization(IRootScopeTypeResolveContext context, TypedStructInitialization typedStructInitialization)
        {
            throw new NotImplementedException();
        }

        private Result<ValueInitialization> PassthroughResolve(IRootScopeTypeResolveContext context, ValueInitialization initialization)
        {
            return Result.FromValue(initialization);
        }
    }
}
