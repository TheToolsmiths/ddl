using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Parser.Ast.Models.Types.Paths;

namespace Ddl.Parser.Resolve.Models.FirstPhase.ImportPaths
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
                while (true)
                {
                    switch (importItem)
                    {
                        case ResolvedImportIdentifierAlias identifierAlias:
                            {
                                var pathPart = new SimpleReferencePathPart(identifierAlias.Identifier);

                                pathParts.Add(pathPart);
                                break;
                            }
                        case ResolvedImportPathItem pathItem:
                            {
                                var pathPart = new SimpleReferencePathPart(pathItem.PathIdentifier);

                                pathParts.Add(pathPart);

                                importItem = pathItem.ChildItem;
                                continue;
                            }
                        default:
                            throw new ArgumentOutOfRangeException(nameof(importItem));
                    }

                    break;
                }
            }

            return isRooted
                ? TypeReferencePath.CreateRootedFromParts(pathParts)
                : TypeReferencePath.CreateFromParts(pathParts);
        }
    }
}
