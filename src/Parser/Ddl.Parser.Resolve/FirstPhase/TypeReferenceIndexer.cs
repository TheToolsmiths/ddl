using System;
using System.Collections.Generic;

using Ddl.Common;
using Ddl.Parser.Resolve.Models.FirstPhase.Items;
using Ddl.Parser.Resolve.Models.FirstPhase.Scopes;
using TheToolsmiths.Ddl.Parser.Models.References.TypeReferences;
using TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.Namespaces;
using TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.References;
using TheToolsmiths.Ddl.Resolve.Common.TypeHelpers;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase
{
    public class TypeReferenceIndexer
    {
        public Result<IReadOnlyList<EntityTypeReference>> IndexResolvedScopeTypes(
            NamespacePath namespacePath,
            FirstPhaseResolvedScope rootScope)
        {
            var context = new ContentUnitTypeIndexingContext(namespacePath);

            {
                var result = this.IndexScopeTypes(context, rootScope);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            return Result.FromValue<IReadOnlyList<EntityTypeReference>>(context.IndexedTypes);
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
                var itemReference = item.ItemReference;

                var typeIdentifier = ResolveTypeIdentifierPathBuilder.Create(context.NamespacePath, itemReference.TypeName);

                var indexedType = new ItemTypePathReference(
                    itemReference.TypeName,
                    context.NamespacePath,
                    itemReference.ItemReference,
                    typeIdentifier);

                context.IndexedTypes.Add(indexedType);
            }

            foreach (var subItemReference in item.SubItemReferences)
            {
                var typeIdentifier = ResolveTypeIdentifierPathBuilder.Create(context.NamespacePath, subItemReference.TypeName);

                var indexedType = new SubItemTypePathReference(
                    subItemReference.TypeName,
                    context.NamespacePath,
                    subItemReference.SubItemReference,
                    typeIdentifier);

                context.IndexedTypes.Add(indexedType);
            }

            return Result.Success;
        }
    }
}
