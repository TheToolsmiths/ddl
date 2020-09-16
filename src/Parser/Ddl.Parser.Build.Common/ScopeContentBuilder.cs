using System;
using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Models.EntryTypes;
using TheToolsmiths.Ddl.Models.ImportPaths;
using TheToolsmiths.Ddl.Parser.Ast.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Parser.Build.Results;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Build.Common
{
    public class ScopeContentBuilder
    {
        private readonly IAstRootItemBuilder itemBuilder;
        private readonly IAstRootScopeBuilder scopeBuilder;

        public ScopeContentBuilder(
            IAstRootItemBuilder itemBuilder,
            IAstRootScopeBuilder scopeBuilder)
        {
            this.itemBuilder = itemBuilder;
            this.scopeBuilder = scopeBuilder;
        }

        public Result<ScopeContent> BuildScopeContent(
            IRootScopeBuildContext scopeContext,
            AstScopeContent scopeContent)
        {
            var buildContext = new ScopeContentBuildContext();

            foreach (var item in scopeContent.Items)
            {
                var context = scopeContext.CreateItemContext();

                var result = this.itemBuilder.BuildItem(context, item);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                if (TryHandleItemBuildResult(buildContext, result) == false)
                {
                    throw new NotImplementedException();
                }
            }

            foreach (var childScope in scopeContent.Scopes)
            {
                var context = scopeContext.CreateScopeContext();

                var result = this.scopeBuilder.BuildScope(context, childScope);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                if (TryHandleScopeBuildResult(buildContext, result) == false)
                {
                    throw new NotImplementedException();
                }
            }

            var rootScope = this.CreateScopeContent(buildContext);

            return Result.FromValue(rootScope);
        }

        private static bool TryHandleItemBuildResult(ScopeContentBuildContext buildContext, RootItemBuildResult result)
        {
            if (!(result is RootItemBuildSuccess successResult))
            {
                return false;
            }

            foreach (var rootItem in successResult.Items)
            {
                if (rootItem.ItemType == CommonItemTypes.ImportStatement)
                {
                    if (rootItem is ImportStatement importStatement)
                    {
                        buildContext.ImportPaths.Add(importStatement);
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                }
                else
                {
                    buildContext.Items.Add(rootItem);
                }
            }

            return true;
        }

        private static bool TryHandleScopeBuildResult(ScopeContentBuildContext buildContext, RootScopeBuildResult result)
        {
            if (!(result is RootScopeBuildSuccess successResult))
            {
                return false;
            }

            buildContext.Scopes.AddRange(successResult.Scopes);

            return true;
        }

        private ScopeContent CreateScopeContent(ScopeContentBuildContext buildContext)
        {
            var items = buildContext.Items;

            var scopes = buildContext.Scopes;

            var importPaths = buildContext.ImportPaths;

            return ScopeContent.Create(items, scopes, importPaths);
        }

        private class ScopeContentBuildContext
        {
            public ScopeContentBuildContext()
            {
                this.Items = new List<IRootItem>();
                this.Scopes = new List<IRootScope>();
                this.ImportPaths = new List<ImportStatement>();
            }

            public List<IRootItem> Items { get; }

            public List<IRootScope> Scopes { get; }

            public List<ImportStatement> ImportPaths { get; }
        }
    }
}
