using System;
using TheToolsmiths.Ddl.Parser.Models.Identifiers;

namespace Ddl.Resolve.Models.FirstPhase.ImportPaths
{
    public static class ResolvedImportRootHelper
    {
        public static Identifier GetAliasIdentifier(ResolvedImportRoot resolvedRoot)
        {
            return GetItemAlias(resolvedRoot.ChildItem);

            static Identifier GetItemAlias(ResolvedImportItem importItem)
            {
                return importItem switch
                {
                    ResolvedImportIdentifierAlias identifierAlias => identifierAlias.AliasIdentifier,
                    ResolvedImportPathItem pathItem => GetItemAlias(pathItem.ChildItem),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
        }
    }
}
