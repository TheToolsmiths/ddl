using System;
using TheToolsmiths.Ddl.Models.Ast.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Models.Build.ContentUnits;
using TheToolsmiths.Ddl.Models.Build.Scopes;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Parser.Build.Results;

namespace TheToolsmiths.Ddl.Parser.Build.Builders
{
    internal class AstContentUnitScopeBuilder : IAstContentUnitScopeBuilder
    {
        public ContentUnitScopeBuildResult BuildScope(IRootScopeBuildContext context, AstContentUnitScope rootScope)
        {
            var result = context.CommonBuilders.BuildScopeContent(rootScope.Content);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            ScopeContent scopeContent = result.Value;

            var contentUnitScope = new ContentUnitScope(scopeContent);

            return new ContentUnitScopeBuildSuccess(contentUnitScope);
        }
    }
}
