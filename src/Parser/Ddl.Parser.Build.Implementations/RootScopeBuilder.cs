using System;
using TheToolsmiths.Ddl.Models.Ast.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Models.Build.AttributeUsage;
using TheToolsmiths.Ddl.Models.Build.Scopes;
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

            AttributeUseCollection attributes;
            {
                var result = scopeContext.CommonBuilders.BuildAttributes(scope.Attributes);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                attributes = result.Value;
            }

            var conditionalScope = new RootScope(scopeContent, attributes);

            var builder = new RootScopeResultBuilder();

            builder.Scopes.Add(conditionalScope);

            return builder.CreateSuccessResult();
        }
    }
}
