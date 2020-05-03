using System;
using Ddl.Common;
using Ddl.Resolve.Models.FirstPhase;
using Ddl.Resolve.Models.FirstPhase.Items;
using Ddl.Resolve.Models.FirstPhase.Scopes;
using Ddl.Resolve.Models.FirstPhase.TypePaths;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase
{
    public class FirstPhaseContentUnitTypeIndexer
    {
        public Result IndexTypes(ContentUnitsCollectionResolveContext context)
        {
            foreach (var contentUnit in context.ContentUnits)
            {
                var indexContext = ContentUnitTypeIndexingContext.FromContentUnit(contentUnit);

                {
                    var result = this.IndexContentUnitTypes(indexContext, contentUnit);

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }
                }

                {
                    var result = this.IntegrateContentUnitIndexing(context, indexContext);

                    if (result.IsError)
                    {
                        throw new NotImplementedException();
                    }
                }
            }

            return Result.Success;
        }

        private Result IntegrateContentUnitIndexing(
            ContentUnitsCollectionResolveContext context,
            ContentUnitTypeIndexingContext indexContext)
        {
            context.IndexedTypes.AddRange(indexContext.IndexedTypes);

            return Result.Success;
        }

        private Result IndexContentUnitTypes(
            ContentUnitTypeIndexingContext context,
            FirstPhaseResolvedContentUnit contentUnit)
        {
            var result = this.IndexScopeTypes(context, contentUnit.RootScope);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            return Result.Success;
        }

        private Result IndexScopeTypes(ContentUnitTypeIndexingContext context, FirstPhaseResolvedScope scope)
        {
            foreach (var item in scope.ResolvedItems)
            {
                var result = this.IndexScopeItem(context, item);

                if (result.IsError)
                {
                    return result;
                }
            }

            foreach (var childScope in scope.ResolvedScopes)
            {
                var result = this.IndexScopeTypes(context, childScope);

                if (result.IsError)
                {
                    return result;
                }
            }

            return Result.Success;
        }

        private Result IndexScopeItem(ContentUnitTypeIndexingContext context, FirstPhaseResolvedItem item)
        {
            if(item.ItemReference != null)
            {
                var typePathReference = item.ItemReference;

                var fullSubItemTypeName = context.NamespacePath.Append(typePathReference.TypeName);

                var itemId = typePathReference.ItemId;

                var contentUnitId = context.ContentUnitId;

                var indexedType = new IndexedTypeItemReference(fullSubItemTypeName, contentUnitId, itemId);

                context.IndexedTypes.Add(indexedType);
            }

            foreach (var typePathReference in item.SubItemReferences)
            {
                var fullSubItemTypeName = context.NamespacePath.Append(typePathReference.TypeName);

                var itemId = typePathReference.ItemId;

                var contentUnitId = context.ContentUnitId;

                var indexedType = new IndexedTypeSubItemReference(fullSubItemTypeName, contentUnitId, itemId, typePathReference.SubItemId);

                context.IndexedTypes.Add(indexedType);
            }

            return Result.Success;
        }
    }
}
