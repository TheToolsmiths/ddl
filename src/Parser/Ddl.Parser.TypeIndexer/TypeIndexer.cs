using System;
using TheToolsmiths.Ddl.Models.Build.ContentUnits;
using TheToolsmiths.Ddl.Models.Build.Items;
using TheToolsmiths.Ddl.Models.Build.Scopes;
using TheToolsmiths.Ddl.Models.Build.Types.References;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Indexers;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Results;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer
{
    internal class TypeIndexer
    {
        private readonly RootItemIndexerResolver indexerResolver;

        public TypeIndexer(RootItemIndexerResolver indexerResolver)
        {
            this.indexerResolver = indexerResolver;
        }

        public Result IndexContentUnitTypes(TypeIndexingContext context, ContentUnitScope rootScope)
        {
            return this.IndexScopeContentTypes(context, rootScope.Content);
        }

        private Result IndexScopeContentTypes(TypeIndexingContext context, ScopeContent scopeContent)
        {
            foreach (var childScope in scopeContent.Scopes)
            {
                var result = this.IndexScopeTypes(context, childScope);

                if (result.IsError)
                {
                    return result;
                }
            }

            foreach (var item in scopeContent.Items)
            {
                var result = this.IndexScopeItem(context, item);

                if (result.IsError)
                {
                    return result;
                }
            }

            return Result.Success;
        }

        private Result IndexScopeTypes(TypeIndexingContext context, IRootScope scope)
        {
            return this.IndexScopeContentTypes(context, scope.Content);
        }

        private Result IndexScopeItem(TypeIndexingContext context, IRootItem item)
        {
            if (item is INamedRootItem == false)
            {
                return Result.Success;
            }

            if (this.indexerResolver.TryResolveItemIndexer(item, out var itemIndexer) == false)
            {
                throw new NotImplementedException();
            }

            var itemContext = context.CreateItemIndexContext();

            var result = itemIndexer.IndexItem(itemContext, item);

            switch (result)
            {
                case RootItemIndexError error:
                    throw new NotImplementedException();

                case RootItemIndexSuccess success:
                    this.HandleIndexSuccess(context, success);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(result));
            }

            return Result.Success;
        }

        private void HandleIndexSuccess(TypeIndexingContext context, RootItemIndexSuccess result)
        {
            if (result.ItemTypeReference != null)
            {
                var itemTypeReference = result.ItemTypeReference;

                var typedItemName = itemTypeReference.TypeName;
                var namespacePath = context.NamespacePath;
                var itemReference = itemTypeReference.ItemReference;

                //var typeIdentifier = TypeIdentifierPathBuilder.Create(namespacePath, typeName);
                
                var typeReference = new ItemTypePathReference(
                    typedItemName,
                    namespacePath,
                    itemReference);

                context.IndexedTypes.Add(typeReference);
            }

            foreach (var subItemTypeReference in result.SubItemTypesReferences)
            {
                var typedSubItemName = subItemTypeReference.TypeName;
                var namespacePath = context.NamespacePath;

                //var typeIdentifier = TypeIdentifierPathBuilder.Create(namespacePath, typedSubItemName);

                var typeReference = new SubItemTypePathReference(
                    typedSubItemName,
                    namespacePath,
                    subItemTypeReference.SubItemReference);

                context.IndexedTypes.Add(typeReference);
            }
        }
    }
}
