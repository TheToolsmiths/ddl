using System;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;

namespace TheToolsmiths.Ddl.Parser.Build.BuildPhase
{
    public class RootScopeBuilder
    {
        //private readonly ContentUnitEntityResolverProvider resolverProvider;

        //public RootScopeBuilder(ContentUnitEntityResolverProvider resolverProvider)
        //{
        //    this.resolverProvider = resolverProvider;
        //}

        public Result BuildScope(ContentUnitScopeBuildContext context, IAstRootScope item)
        {
            throw new NotImplementedException();

            //var result = item switch
            //{
            //    ConditionalAstRootScope rootScope => this.resolverProvider.CreateRootScopeResolver()
            //        .CatalogScope(context, rootScope),

            //    _ => throw new ArgumentOutOfRangeException(nameof(item))
            //};

            //if (result.IsError)
            //{
            //    throw new NotImplementedException();
            //}

            //return Result.Success;
        }
    }
}
