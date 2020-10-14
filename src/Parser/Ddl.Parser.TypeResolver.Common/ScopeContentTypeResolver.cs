using System;
using TheToolsmiths.Ddl.Models.Build.ContentUnits.Items;
using TheToolsmiths.Ddl.Models.Build.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Parser.TypeResolver.Contexts;
using TheToolsmiths.Ddl.Parser.TypeResolver.Results;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.TypeResolver.Common
{
    public class ScopeContentTypeResolver
    {
        private readonly IRootItemTypeResolver itemTypeResolver;
        private readonly IRootScopeTypeResolver scopeTypeResolver;

        public ScopeContentTypeResolver(
            IRootScopeTypeResolver scopeTypeResolver,
            IRootItemTypeResolver itemTypeResolver)
        {
            this.scopeTypeResolver = scopeTypeResolver;
            this.itemTypeResolver = itemTypeResolver;
        }

        public Result<ScopeContent> ResolveScopeContent(IRootScopeTypeResolveContext context, ScopeContent scopeContent)
        {
            var builder = new ScopeContentBuilder();

            var updatedContext = context.AddImportPaths(context, scopeContent.Imports);

            foreach (var childScope in scopeContent.Scopes)
            {
                var result = this.IndexScopeTypes(updatedContext, builder, childScope);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            foreach (var item in scopeContent.Items)
            {
                var result = this.IndexScopeItem(updatedContext, builder, item);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            var content = builder.Build();

            return Result.FromValue(content);
        }

        private Result IndexScopeItem(
            IRootScopeTypeResolveContext context,
            ScopeContentBuilder builder,
            IRootItem item)
        {
            var itemContext = context.CreateItemContext();

            var result = this.itemTypeResolver.ResolveItem(itemContext, item);

            switch (result)
            {
                case RootItemTypeResolveError error:
                    throw new NotImplementedException();

                case RootItemTypeResolveSuccess success:
                    builder.Items.Add(success.ResolvedItem);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(result));
            }

            return Result.Success;
        }

        private Result IndexScopeTypes(
            IRootScopeTypeResolveContext context,
            ScopeContentBuilder builder,
            IRootScope scope)
        {
            var scopeContext = context.CreateScopeContext();

            var result = this.scopeTypeResolver.ResolveScopeTypes(scopeContext, scope);

            switch (result)
            {
                case RootScopeTypeResolveError error:
                    throw new NotImplementedException();

                case RootScopeTypeResolveSuccess success:
                    builder.Scopes.Add(success.ResolvedScope);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(result));
            }

            return Result.Success;
        }
    }
}
