namespace TheToolsmiths.Ddl.TypeResolution
{
    public class TypeReferenceIndexer
    {
        //public Result<IReadOnlyList<EntityTypeReference>> IndexResolvedScopeTypes(
        //    NamespacePath namespacePath,
        //    FirstPhaseResolvedScope rootScope)
        //{
        //    var context = new ContentUnitTypeIndexingContext(namespacePath);

        //    {
        //        var result = this.IndexScopeTypes(context, rootScope);

        //        if (result.IsError)
        //        {
        //            throw new NotImplementedException();
        //        }
        //    }

        //    return Result.FromValue<IReadOnlyList<EntityTypeReference>>(context.IndexedTypes);
        //}

        //private Result IndexScopeTypes(ContentUnitTypeIndexingContext context, FirstPhaseResolvedScope scope)
        //{
        //    foreach (var childScope in scope.Scopes)
        //    {
        //        var result = this.IndexScopeTypes(context, childScope);

        //        if (result.IsError)
        //        {
        //            return result;
        //        }
        //    }

        //    foreach (var item in scope.Items)
        //    {
        //        var result = this.IndexScopeItem(context, item);

        //        if (result.IsError)
        //        {
        //            return result;
        //        }
        //    }

        //    return Result.Success;
        //}

        //private Result IndexScopeItem(ContentUnitTypeIndexingContext context, FirstPhaseResolvedItem item)
        //{
        //    if (item.ItemReference != null)
        //    {
        //        var itemReference = item.ItemReference;

        //        var typeIdentifier = TypeIdentifierPathBuilder.Create(context.NamespacePath, itemReference.TypeName);

        //        var indexedType = new ItemTypePathReference(
        //            itemReference.TypeName,
        //            context.NamespacePath,
        //            itemReference.ItemReference,
        //            typeIdentifier);

        //        context.IndexedTypes.Add(indexedType);
        //    }

        //    foreach (var subItemReference in item.SubItemReferences)
        //    {
        //        var typeIdentifier = TypeIdentifierPathBuilder.Create(context.NamespacePath, subItemReference.TypeName);

        //        var indexedType = new SubItemTypePathReference(
        //            subItemReference.TypeName,
        //            context.NamespacePath,
        //            subItemReference.SubItemReference,
        //            typeIdentifier);

        //        context.IndexedTypes.Add(indexedType);
        //    }

        //    return Result.Success;
        //}
    }
}
