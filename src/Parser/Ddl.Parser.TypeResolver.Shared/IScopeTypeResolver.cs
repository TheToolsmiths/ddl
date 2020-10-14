using TheToolsmiths.Ddl.Models.Build.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.TypeResolver.Contexts;
using TheToolsmiths.Ddl.Parser.TypeResolver.Results;

namespace TheToolsmiths.Ddl.Parser.TypeResolver
{

    public interface IScopeTypeResolver<TScope> : IScopeTypeResolver
        where TScope : class, IRootScope
    {
        public RootScopeTypeResolveResult ResolveScopeTypes(IRootScopeTypeResolveContext scopeContext, TScope scope);
    }

    public interface IScopeTypeResolver
    {
    }
}
