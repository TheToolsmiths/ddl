using System;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits;
using TheToolsmiths.Ddl.Parser.Build.BuildPhase;
using TheToolsmiths.Ddl.Parser.Build.Models.ContentUnits;

namespace TheToolsmiths.Ddl.Parser.Build
{
    internal class DdlContentUnitBuilder
    {
        private readonly ScopeContentBuilder rootScopeBuilder;

        public DdlContentUnitBuilder(ScopeContentBuilder rootScopeBuilder)
        {
            this.rootScopeBuilder = rootScopeBuilder;
        }

        public Result Build(AstContentUnit astContentUnit)
        {
            var scopeContext = ContentUnitScopeBuildContext.CreateRootContext();

            var result = this.rootScopeBuilder
                .BuildScopeContent(scopeContext, astContentUnit.FileRootScope.Content);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var rootScope = result.Value;

            var resolvedContentUnit = new FirstPhaseResolvedContentUnit(astContentUnit.Id, rootScope);

            throw new NotImplementedException();
        }
    }
}
