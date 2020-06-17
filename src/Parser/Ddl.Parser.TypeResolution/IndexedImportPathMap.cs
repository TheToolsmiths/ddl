using TheToolsmiths.Ddl.Models.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.TypeResolution
{
    public class IndexedImportPathMap
    {
        //private readonly IReadOnlyList<ImportStatement> importPaths;
        private readonly NamespacePath scopeNamespace;

        //private IndexedImportPathMap(
        //    NamespacePath scopeNamespace,
        //    IReadOnlyList<ImportStatement> importPaths)
        //{
        //    this.importPaths = importPaths;
        //    this.scopeNamespace = scopeNamespace;
        //}

        //public static IndexedImportPathMap FromImportPaths(
        //    NamespacePath scopeNamespace,
        //    IReadOnlyList<ImportStatement> importPaths)
        //{
        //    return new IndexedImportPathMap(scopeNamespace, importPaths);
        //}

        //public bool TryResolveType(TypeReferencePath lookupPath, [MaybeNullWhen(false)] out TypeResolution typeResolution)
        //{
        //    // If lookup path is rooted, ignore any import paths
        //    if (lookupPath.IsRooted)
        //    {
        //        typeResolution = TypeResolution.Unresolved;
        //        return false;
        //    }

        //    foreach (var importPath in this.importPaths)
        //    {
        //        if (TypeReferencePathComparer.StartsWithName(lookupPath, importPath.Alias))
        //        {
        //            typeResolution = new MatchImportResolution(importPath.ImportPath, lookupPath, this.scopeNamespace);
        //            return true;
        //        }
        //    }

        //    typeResolution = TypeResolution.Unresolved;
        //    return false;
        //}
    }
}
