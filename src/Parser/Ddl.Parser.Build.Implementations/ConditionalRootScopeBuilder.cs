using System;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Parser.Build.Results;
using TheToolsmiths.Ddl.Parser.Models.ContentUnits.Scopes;

namespace TheToolsmiths.Ddl.Parser.Build.Implementations
{
    public class ConditionalRootScopeBuilder : IRootScopeBuilder<ConditionalRootScope>
    {
        //private readonly ScopeContentResolver scopeResolver;

        //public ConditionalRootScopeBuilder(ScopeContentResolver scopeResolver)
        //{
        //    this.scopeResolver = scopeResolver;
        //}

        public RootScopeBuildResult<ConditionalRootScope> CatalogScope(IRootItemBuildContext unitContext, IAstRootScope scope)
        {
            throw new NotImplementedException();
        }

        public Result CatalogScope(IRootItemBuildContext unitContext, ConditionalRootScope scope)
        {
            throw new NotImplementedException();

            //var additionalProperties = new List<FirstPhaseResolvedScopeProperty>();

            //if (scope.ConditionalExpression.IsEmpty == false)
            //{
            //    additionalProperties.Add(new ConditionalProperty(scope.ConditionalExpression));
            //}

            //var scopeContext = unitContext.CreateScopeWithAdditionalProperties(additionalProperties);

            //var result = this.scopeResolver.ResolveScopeContent(scopeContext, scope.Content);

            //if (result.IsError)
            //{
            //    throw new System.NotImplementedException();
            //}

            //var resolvedScope = result.Value;

            //unitContext.ResolvedScopes.Add(resolvedScope);

            //return Result.Success;
        }
    }
}
