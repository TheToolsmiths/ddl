using System;

using TheToolsmiths.Ddl.Models.ConditionalExpressions;
using TheToolsmiths.Ddl.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Parser.Build.Results;

namespace TheToolsmiths.Ddl.Parser.Build.Implementations
{
    public class ConditionalRootScopeBuilder : IRootScopeBuilder<ConditionalAstRootScope>
    {
        public RootScopeBuildResult BuildScope(IRootScopeBuildContext scopeContext, ConditionalAstRootScope scope)
        {
            ConditionalExpression conditionalExpression;
            {
                var result = scopeContext.CommonBuilders.BuildConditionalExpression(scope.ConditionalExpression);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                conditionalExpression = result.Value;
            }

            ScopeContent scopeContent;
            {
                var result = scopeContext.CommonBuilders.BuildScopeContent(scope.Content);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                scopeContent = result.Value;
            }

            var conditionalScope = new ConditionalRootScope(conditionalExpression, scopeContent);

            var builder = new RootScopeResultBuilder();

            builder.Scopes.Add(conditionalScope);

            return builder.CreateSuccessResult();
        }
    }
}
