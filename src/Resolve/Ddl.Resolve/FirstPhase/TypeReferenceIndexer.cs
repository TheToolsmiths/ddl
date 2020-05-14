using System;
using System.Collections.Generic;
using Ddl.Common;
using Ddl.Common.Models;
using Ddl.Resolve.Models.FirstPhase.Indexing;
using Ddl.Resolve.Models.FirstPhase.Items;
using Ddl.Resolve.Models.FirstPhase.Scopes;
using Ddl.Resolve.Models.FirstPhase.TypePaths;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase
{
    public class TypeReferenceIndexer
    {
        public Result<IReadOnlyList<IndexedTypeReference>> IndexResolvedScopeTypes(
            in ContentUnitId contentUnitId,
            FirstPhaseNamespacePath namespacePath,
            FirstPhaseResolvedScope rootScope)
        {
            var context = new ContentUnitTypeIndexingContext(contentUnitId, namespacePath);

            {
                var result = this.IndexScopeTypes(context, rootScope);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            return Result.FromValue<IReadOnlyList<IndexedTypeReference>>(context.IndexedTypes);
        }

        private Result IndexScopeTypes(ContentUnitTypeIndexingContext context, FirstPhaseResolvedScope scope)
        {
            foreach (var childScope in scope.Scopes)
            {
                var result = this.IndexScopeTypes(context, childScope);

                if (result.IsError)
                {
                    return result;
                }
            }

            foreach (var item in scope.Items)
            {
                var result = this.IndexScopeItem(context, item);

                if (result.IsError)
                {
                    return result;
                }
            }

            return Result.Success;
        }

        private Result IndexScopeItem(ContentUnitTypeIndexingContext context, FirstPhaseResolvedItem item)
        {
            if (item.ItemReference != null)
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
