﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Ddl.Resolve.Models.FirstPhase.ImportPaths;
using Ddl.Resolve.Models.TypeResolve;
using TheToolsmiths.Ddl.Parser.Models.Types.Namespaces;
using TheToolsmiths.Ddl.Parser.Models.Types.Paths;

namespace TheToolsmiths.Ddl.Resolve.SecondPhase
{
    public class IndexedImportPathMap
    {
        private readonly IReadOnlyList<FirstPhaseResolvedImportPath> importPaths;
        private readonly NamespacePath scopeNamespace;

        private IndexedImportPathMap(
            NamespacePath scopeNamespace,
            IReadOnlyList<FirstPhaseResolvedImportPath> importPaths)
        {
            this.importPaths = importPaths;
            this.scopeNamespace = scopeNamespace;
        }

        public static IndexedImportPathMap FromImportPaths(
            NamespacePath scopeNamespace,
            IReadOnlyList<FirstPhaseResolvedImportPath> importPaths)
        {
            return new IndexedImportPathMap(scopeNamespace, importPaths);
        }

        public bool TryResolveType(TypeIdentifierPath lookupPath, [MaybeNullWhen(false)] out ResolvedType resolvedType)
        {
            var referenceLookupPath = TypeReferencePath.CreateFromIdentifierPath(lookupPath);

            return this.TryResolveType(referenceLookupPath, out resolvedType);
        }

        public bool TryResolveType(TypeReferencePath lookupPath, [MaybeNullWhen(false)] out ResolvedType resolvedType)
        {
            // If lookup path is rooted, ignore any import paths
            if (lookupPath.IsRooted)
            {
                resolvedType = default;
                return false;
            }

            foreach (var importPath in this.importPaths)
            {
                if (TypeReferencePathComparer.StartsWithName(lookupPath, importPath.Alias))
                {
                    resolvedType = new ResolvedTypePath(importPath.ImportRoot, lookupPath, this.scopeNamespace);
                    return true;
                }
            }

            resolvedType = default;
            return false;
        }
    }
}