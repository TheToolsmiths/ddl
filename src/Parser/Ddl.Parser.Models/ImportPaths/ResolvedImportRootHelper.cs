using System;

namespace TheToolsmiths.Ddl.Parser.Models.ImportPaths
{
    public static class ResolvedImportRootHelper
    {
        public static string GetAliasIdentifier(ResolvedImportRoot resolvedRoot)
        {
            return GetItemAlias(resolvedRoot.ChildItem);

            static string GetItemAlias(ResolvedImportItem importItem)
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
