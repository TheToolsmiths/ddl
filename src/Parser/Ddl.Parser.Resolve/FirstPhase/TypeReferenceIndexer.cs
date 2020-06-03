﻿using System;
using System.Collections.Generic;
using Ddl.Common;
using Ddl.Parser.Resolve.Models.Common.TypeReferences;
using Ddl.Parser.Resolve.Models.FirstPhase.Items;
using Ddl.Parser.Resolve.Models.FirstPhase.Scopes;
using TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase
{
    public class TypeReferenceIndexer
    {
        public Result<IReadOnlyList<TypePathEntityReference>> IndexResolvedScopeTypes(
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

            return Result.FromValue<IReadOnlyList<TypePathEntityReference>>(context.IndexedTypes);
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
                var typeReference = item.ItemReference;
                
                var indexedType = new TypePathItemReference(typeReference.TypeName, context.NamespacePath, typeReference.ItemReference);

                context.IndexedTypes.Add(indexedType);
            }

            foreach (var typeReference in item.SubItemReferences)
            {
                var indexedType = new TypePathSubItemReference(typeReference.TypeName, context.NamespacePath, typeReference.SubItemReference);

                context.IndexedTypes.Add(indexedType);
            }

            return Result.Success;
        }
    }
}
