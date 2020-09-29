using System;
using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Parser.Build.Results;

namespace TheToolsmiths.Ddl.Parser.Build.Builders
{
    internal class AstContentUnitScopeBuilder : IAstContentUnitScopeBuilder
    {
        private readonly IAstRootScopeBuilder scopeBuilder;

        public AstContentUnitScopeBuilder(IAstRootScopeBuilder scopeBuilder)
        {
            this.scopeBuilder = scopeBuilder;
        }

        public ContentUnitScopeBuildResult BuildScope(IRootScopeBuildContext context, IAstRootScope rootScope)
        {
            var result = this.scopeBuilder.BuildScope(context, rootScope);

            if (result is RootScopeBuildSuccess success)
            {
                var scopeContent = ScopeContent.Create(success.Scopes);

                var contentUnitScope = new ContentUnitScope(scopeContent);

                return new ContentUnitScopeBuildSuccess(contentUnitScope);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
