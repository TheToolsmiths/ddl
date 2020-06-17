using System;

using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Parser.Build.Results;

namespace TheToolsmiths.Ddl.Parser.Build.Implementations
{
    public class ConditionalRootScopeBuilder : IRootScopeBuilder<ConditionalAstRootScope>
    {
        //private readonly ScopeContentResolver scopeResolver;

        //public ConditionalRootScopeBuilder(ScopeContentResolver scopeResolver)
        //{
        //    this.scopeResolver = scopeResolver;
        //}

        public RootScopeBuildResult BuildScope(IRootItemBuildContext unitContext, ConditionalAstRootScope scope)
        {
            throw new NotImplementedException();

            //var additionalProperties = new List<ScopeProperty>();

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
