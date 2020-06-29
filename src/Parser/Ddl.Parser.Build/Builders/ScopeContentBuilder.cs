using System;
using TheToolsmiths.Ddl.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Build.Builders
{
    internal class ScopeContentBuilder
    {
        private readonly RootItemBuilder itemBuilder;
        private readonly RootScopeBuilder scopeBuilder;

        public ScopeContentBuilder(
            RootItemBuilder itemBuilder,
            RootScopeBuilder scopeBuilder)
        {
            this.itemBuilder = itemBuilder;
            this.scopeBuilder = scopeBuilder;
        }

        public Result<ScopeContent> BuildScopeContent(
            ContentUnitScopeBuildContext parentContext,
            IAstRootScope scope)
        {
            var scopeContext = parentContext.CreateChildContext();

            var scopeContent = scope.Content;

            foreach (var item in scopeContent.Items)
            {
                var result = this.itemBuilder.BuildItem(scopeContext, item);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            foreach (var childScope in scopeContent.Scopes)
            {
                var result = this.scopeBuilder.BuildScope(scopeContext, childScope);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            throw new NotImplementedException();

            ////var rootScope = scopeContext.BuildResolvedScope();

            ////return Result.FromValue(rootScope);
        }
    }
}
