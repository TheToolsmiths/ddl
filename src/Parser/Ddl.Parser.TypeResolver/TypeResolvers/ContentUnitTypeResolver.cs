using System;

using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Parser.TypeResolver.Contexts;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.TypeResolvers
{
    internal class ContentUnitTypeResolver : IContentUnitTypeResolver
    {
        public Result<ContentUnitScope> ResolveContentUnitScopeTypes(
            IRootScopeTypeResolveContext context,
            ContentUnitScope rootScope)
        {
            var result = context.CommonTypeResolvers.ResolveScopeContent(rootScope.Content);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var scopeContent = result.Value;

            return Result.FromValue(new ContentUnitScope(scopeContent));
        }
    }
}
