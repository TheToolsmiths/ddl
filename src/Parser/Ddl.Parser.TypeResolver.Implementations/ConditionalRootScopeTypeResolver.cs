using TheToolsmiths.Ddl.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.TypeResolver.Contexts;
using TheToolsmiths.Ddl.Parser.TypeResolver.Results;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.Implementations
{
    internal class ConditionalRootScopeTypeResolver : IScopeTypeResolver<ConditionalRootScope>
    {
        public RootScopeTypeResolveResult ResolveScopeTypes(IRootScopeTypeResolveContext scopeContext, ConditionalRootScope scope)
        {
            var result = scopeContext.CommonTypeResolvers.ResolveScopeContent(scope.Content);

            throw new System.NotImplementedException();
        }
    }
}
