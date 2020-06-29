using System;

using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits;
using TheToolsmiths.Ddl.Parser.Build.Builders;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Build
{
    internal class DdlContentUnitBuilder
    {
        private readonly ScopeContentBuilder rootScopeBuilder;
        private readonly ICommonBuilders commonBuilders;

        public DdlContentUnitBuilder(ScopeContentBuilder rootScopeBuilder, ICommonBuilders commonBuilders)
        {
            this.rootScopeBuilder = rootScopeBuilder;
            this.commonBuilders = commonBuilders;
        }

        public Result Build(AstContentUnit astContentUnit)
        {
            var scopeContext = ContentUnitScopeBuildContext.CreateRootContext(this.commonBuilders);

            var result = this.rootScopeBuilder
                .BuildScopeContent(scopeContext, astContentUnit.FileRootScope);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var rootScope = result.Value;

            //var resolvedContentUnit = new ContentUnit(astContentUnit.Id, rootScope);

            throw new NotImplementedException();
        }
    }
}
