using TheToolsmiths.Ddl.Parser.Models.Types.TypePaths.Namespaces;

namespace TheToolsmiths.Ddl.TypeResolution
{
    public class IndexedImportPathMap
    {
        //private readonly IReadOnlyList<FirstPhaseResolvedImportPath> importPaths;
        private readonly NamespacePath scopeNamespace;

        //private IndexedImportPathMap(
        //    NamespacePath scopeNamespace,
        //    IReadOnlyList<FirstPhaseResolvedImportPath> importPaths)
        //{
        //    this.importPaths = importPaths;
        //    this.scopeNamespace = scopeNamespace;
        //}

        //public static IndexedImportPathMap FromImportPaths(
        //    NamespacePath scopeNamespace,
        //    IReadOnlyList<FirstPhaseResolvedImportPath> importPaths)
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
        //            typeResolution = new MatchImportResolution(importPath.ImportRoot, lookupPath, this.scopeNamespace);
        //            return true;
        //        }
        //    }

        //    typeResolution = TypeResolution.Unresolved;
        //    return false;
        //}
    }
}
