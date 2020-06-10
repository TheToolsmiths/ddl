using System;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Build.Models.Scopes;

namespace TheToolsmiths.Ddl.Parser.Build.BuildPhase
{
    public class ScopeContentBuilder
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

        public Result<FirstPhaseResolvedScope> BuildScopeContent(
            ContentUnitScopeBuildContext parentContext,
            AstScopeContent scopeContent)
        {
            var scopeContext = parentContext.CreateChildContext();

            foreach (var item in scopeContent.Items)
            {
                var result = this.itemBuilder.BuildItem(scopeContext, item);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            foreach (var scope in scopeContent.Scopes)
            {
                var result = this.scopeBuilder.BuildScope(scopeContext, scope);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            var rootScope = scopeContext.BuildResolvedScope();

            return Result.FromValue(rootScope);
        }
    }
}
