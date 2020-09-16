using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Types.References;
using TheToolsmiths.Ddl.Models.Types.References.Resolve;

namespace TheToolsmiths.Ddl.Models.Types.Resolution
{
    public static class ResolvedTypeKindHelper
    {
        public static ResolvedTypeKind GetResolvedKind(IEnumerable<TypeReference> typeReferences)
        {
            bool hasReferences = false;
            bool hasUnresolved = false;
            bool hasPartialResolved = false;
            bool hasFullResolved = false;

            throw new NotImplementedException();

            //foreach (var typeReference in typeReferences)
            //{
            //    hasReferences = true;

            //    switch (typeReference.TypeResolution)
            //    {
            //        case MatchImportResolution _:
            //            hasPartialResolved = true;
            //            break;
            //        case ResolvedType _:
            //            hasFullResolved = true;
            //            break;
            //        case UnresolvedType _:
            //            hasUnresolved = true;
            //            break;
            //        default:
            //            throw new ArgumentOutOfRangeException();
            //    }
            //}

            if (hasReferences == false)
            {
                return ResolvedTypeKind.Unresolved;
            }

            //if (hasUnresolved)
            //{
            //    return hasFullResolved || hasPartialResolved
            //        ? ResolvedTypeKind.Incomplete
            //        : ResolvedTypeKind.Unresolved;
            //}

            //if (hasPartialResolved)
            //{
            //    return ResolvedTypeKind.Incomplete;
            //}

            throw new NotImplementedException();

            return ResolvedTypeKind.Resolved;
        }
    }
}
