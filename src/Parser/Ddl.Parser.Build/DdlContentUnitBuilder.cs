using System;
using System.Linq;

using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits;
using TheToolsmiths.Ddl.Parser.Build.Builders;
using TheToolsmiths.Ddl.Parser.Build.Results;
using TheToolsmiths.Ddl.Parser.Helpers.ContentUnits;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Build
{
    internal class DdlContentUnitBuilder
    {
        private readonly IAstRootScopeBuilder scopeBuilder;
        private readonly IServiceProvider serviceProvider;

        public DdlContentUnitBuilder(IAstRootScopeBuilder scopeBuilder, IServiceProvider serviceProvider)
        {
            this.scopeBuilder = scopeBuilder;
            this.serviceProvider = serviceProvider;
        }

        public Result<ContentUnit> Build(AstContentUnit astContentUnit)
        {
            var scopeContext = RootScopeBuildContext.CreateRootContext(serviceProvider);

            var result = this.scopeBuilder.BuildScope(scopeContext, astContentUnit.FileRootScope);

            IRootScope rootScope;
            if (result is RootScopeBuildSuccess success)
            {
                if (success.Scopes.Count != 1)
                {
                    throw new NotImplementedException();
                }

                rootScope = success.Scopes.First();
            }
            else if (result is RootScopeBuildError error)
            {
                throw new NotImplementedException();
            }
            else
            {
                throw new NotImplementedException();
            }

            var contentUnitId = ContentUnitId.CreateNew();

            var info = AstContentUnitInfoHelper.ToContentUnitInfo(astContentUnit.Info);
            var contentUnit = new ContentUnit(contentUnitId, info, rootScope);

            return Result.FromValue(contentUnit);
        }
    }
}
