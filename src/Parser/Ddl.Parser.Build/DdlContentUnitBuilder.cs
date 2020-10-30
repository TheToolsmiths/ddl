using System;
using TheToolsmiths.Ddl.Models.Ast.ContentUnits;
using TheToolsmiths.Ddl.Models.Build.ContentUnits;
using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Parser.Build.Builders;
using TheToolsmiths.Ddl.Parser.Build.Results;
using TheToolsmiths.Ddl.Parser.Helpers.ContentUnits;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Build
{
    internal class DdlContentUnitBuilder
    {
        private readonly IAstContentUnitScopeBuilder scopeBuilder;
        private readonly IServiceProvider serviceProvider;

        public DdlContentUnitBuilder(IAstContentUnitScopeBuilder scopeBuilder, IServiceProvider serviceProvider)
        {
            this.scopeBuilder = scopeBuilder;
            this.serviceProvider = serviceProvider;
        }

        public Result<ContentUnit> Build(AstContentUnit astContentUnit)
        {
            var scopeContext = RootScopeBuildContext.CreateRootContext(this.serviceProvider);

            var result = this.scopeBuilder.BuildScope(scopeContext, astContentUnit.FileRootScope);

            ContentUnitScope rootScope;
            if (result is ContentUnitScopeBuildSuccess success)
            {
                rootScope = success.Scope;
            }
            else if (result is ContentUnitScopeBuildError error)
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
