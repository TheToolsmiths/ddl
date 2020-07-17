using System;

using TheToolsmiths.Ddl.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Parser.Build.Results;

namespace TheToolsmiths.Ddl.Parser.Build.Implementations
{
    public class RootScopeBuilder : IRootScopeBuilder<AstRootScope>
    {
        public RootScopeBuildResult BuildScope(IRootScopeBuildContext scopeContext, AstRootScope scope)
        {
            ScopeContent scopeContent;
            {
                var result = scopeContext.CommonBuilders.BuildScopeContent(scope.Content);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                scopeContent = result.Value;
            }

            var conditionalScope = new RootScope(scopeContent);

            var builder = new RootScopeResultBuilder();

            builder.Scopes.Add(conditionalScope);

            return builder.CreateSuccessResult();
        }
    }
}
