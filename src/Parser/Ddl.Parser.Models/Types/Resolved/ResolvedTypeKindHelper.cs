using System;
using System.Collections.Generic;

using TheToolsmiths.Ddl.Parser.Models.Types.References;

namespace TheToolsmiths.Ddl.Parser.Models.Types.Resolved
{
    public static class ResolvedTypeKindHelper
    {
        public static ResolvedTypeKind GetResolvedKind(IEnumerable<TypeReference> typeReferences)
        {
            bool hasReferences = false;
            bool hasUnresolved = false;
            bool hasPartialResolved = false;
            bool hasFullResolved = false;

            foreach (var typeReference in typeReferences)
            {
                hasReferences = true;

                switch (typeReference.TypeResolution)
                {
                    case MatchImportResolution _:
                        hasPartialResolved = true;
                        break;
                    case ResolvedType _:
                        hasFullResolved = true;
                        break;
                    case UnresolvedType _:
                        hasUnresolved = true;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            if (hasReferences == false)
            {
                return ResolvedTypeKind.Unresolved;
            }

            if (hasUnresolved)
            {
                return hasFullResolved || hasPartialResolved
                    ? ResolvedTypeKind.Incomplete
                    : ResolvedTypeKind.Unresolved;
            }

            if (hasPartialResolved)
            {
                return ResolvedTypeKind.Incomplete;
            }

            return ResolvedTypeKind.Resolved;
        }
    }
}
