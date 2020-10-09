using System;

using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Models.ContentUnits.Items;
using TheToolsmiths.Ddl.Models.ContentUnits.Scopes;
using TheToolsmiths.Ddl.Models.References.TypeReferences;
using TheToolsmiths.Ddl.Models.Types.TypePaths.Identifiers;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Indexers;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Results;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer
{
    internal class TypeIndexer
    {
        private readonly RootIndexerResolver indexerResolver;

        public TypeIndexer(RootIndexerResolver indexerResolver)
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
            if (item is ITypedRootItem == false)
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

                var typedItemName = itemTypeReference.Name;
                var namespacePath = context.NamespacePath;
                var itemReference = itemTypeReference.ItemReference;
                var typeIdentifier = TypeIdentifierPathBuilder.Create(namespacePath, typedItemName);
                var typeReference = new ItemTypePathReference(
                    typedItemName,
                    namespacePath,
                    itemReference,
                    typeIdentifier);

                context.IndexedTypes.Add(typeReference);
            }

            foreach (var subItemTypeReference in result.SubItemTypesReferences)
            {
                var typedSubItemName = subItemTypeReference.Name;
                var namespacePath = context.NamespacePath;

                var typeIdentifier = TypeIdentifierPathBuilder.Create(namespacePath, typedSubItemName);

                var typeReference = new SubItemTypePathReference(
                    typedSubItemName,
                    namespacePath,
                    subItemTypeReference.SubItemReference,
                    typeIdentifier);

                context.IndexedTypes.Add(typeReference);
            }
        }
    }
}
