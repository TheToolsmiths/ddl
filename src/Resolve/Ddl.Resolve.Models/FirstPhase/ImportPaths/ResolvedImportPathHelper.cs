using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Models.Types.Paths;

namespace Ddl.Resolve.Models.FirstPhase.ImportPaths
{
    public static class ResolvedImportPathHelper
    {
        public static TypeReferencePath ConvertToTypeReferencePath(ResolvedImportRoot importRoot)
        {
            bool isRooted = importRoot.IsRooted;

            List<TypeReferencePathPart> pathParts = new List<TypeReferencePathPart>();

            ConvertToPathPart(importRoot.ChildItem);

            void ConvertToPathPart(ResolvedImportItem importItem)
            {
                TypeReferencePathPart pathPart;
                switch (importItem)
                {
                    case ResolvedImportIdentifierAlias identifierAlias:
                        pathPart = new SimpleReferencePathPart(identifierAlias.Identifier);

                        pathParts.Add(pathPart);
                        break;
                    case ResolvedImportPathItem pathItem:
                        pathPart = new SimpleReferencePathPart(pathItem.PathIdentifier);

                        pathParts.Add(pathPart);

                        ConvertToPathPart(pathItem.ChildItem);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(importItem));
                }
            }

            return isRooted
                ? TypeReferencePath.CreateRootedFromParts(pathParts)
                : TypeReferencePath.CreateFromParts(pathParts);
        }
    }
}
