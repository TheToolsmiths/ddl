using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TheToolsmiths.Ddl.Models.ImportPaths;
using TheToolsmiths.Ddl.Models.Types.Resolution;
using TheToolsmiths.Ddl.Models.Types.TypePaths.Namespaces;
using TheToolsmiths.Ddl.Models.Types.TypePaths.References;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer
{
    public class IndexedImportPathMap
    {
        private readonly IReadOnlyList<ImportStatement> importPaths;
        private readonly NamespacePath scopeNamespace;

        private IndexedImportPathMap(
            NamespacePath scopeNamespace,
            IReadOnlyList<ImportStatement> importPaths)
        {
            this.importPaths = importPaths;
            this.scopeNamespace = scopeNamespace;
        }

        public static IndexedImportPathMap FromImportPaths(
            NamespacePath scopeNamespace,
            IReadOnlyList<ImportStatement> importPaths)
        {
            return new IndexedImportPathMap(scopeNamespace, importPaths);
        }

        public bool TryResolveType(TypeReferencePath lookupPath, [MaybeNullWhen(false)] out Models.Types.Resolution.TypeResolution typeResolution)
        {
            // If lookup path is rooted, ignore any import paths
            if (lookupPath.IsRooted)
            {
                throw new NotImplementedException();
                //typeResolution = TypeResolution.Unresolved;
                return false;
            }

            foreach (var importPath in this.importPaths)
            {
                if (TypeReferencePathComparer.StartsWithName(lookupPath, importPath.Alias))
                {
                    typeResolution = new MatchImportResolution(importPath.ImportPath, lookupPath, this.scopeNamespace);
                    return true;
                }
            }

            throw new NotImplementedException();
            //typeResolution = TypeResolution.Unresolved;
            return false;
        }
    }
}
