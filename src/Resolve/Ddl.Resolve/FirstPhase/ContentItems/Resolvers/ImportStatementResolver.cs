using System;
using System.Collections.Generic;
using Ddl.Common;
using Ddl.Resolve.Models.FirstPhase.ImportPaths;
using TheToolsmiths.Ddl.Parser.Models.Imports;

namespace TheToolsmiths.Ddl.Resolve.FirstPhase.ContentItems.Resolvers
{
    public class ImportStatementResolver : IRootContentItemResolver<ImportStatement>
    {
        public Result CatalogItem(
            ContentUnitScopeResolveContext unitContext,
            ImportStatement item)
        {
            var result = this.CreateImportList(item.RootItem);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            unitContext.ResolvedImportPaths.AddRange(result.Value);

            return Result.Success;
        }

        private Result<IReadOnlyList<FirstPhaseResolvedImportPath>> CreateImportList(ImportItem rootItem)
        {
            Result<IReadOnlyList<ResolvedImportItem>> result;
            bool isRoot;
            if (rootItem is ImportRoot importRootItem)
            {
                isRoot = true;
                result = this.ProcessImportPath(importRootItem.ChildItem);
            }
            else
            {
                isRoot = false;
                result = this.ProcessImportPath(rootItem);
            }

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var childrenPaths = result.Value;

            var importPaths = new List<FirstPhaseResolvedImportPath>();

            foreach (var path in childrenPaths)
            {
                var resolvedRoot = isRoot
                    ? ResolvedImportRoot.CreateRooted(path)
                    : ResolvedImportRoot.CreateNonRooted(path);

                var resolvedItem = new FirstPhaseResolvedImportPath(resolvedRoot);

                importPaths.Add(resolvedItem);
            }

            return Result.FromValue<IReadOnlyList<FirstPhaseResolvedImportPath>>(importPaths);
        }

        private Result<IReadOnlyList<ResolvedImportItem>> ProcessImportPath(ImportItem importItem)
        {
            return importItem switch
            {
                ImportGroup import => this.ProcessImportGroup(import),
                ImportIdentifier import => this.ProcessImportIdentifier(import),
                ImportIdentifierAlias import => this.ProcessImportIdentifierAlias(import),
                ImportPathItem import => this.ProcessImportPathItem(import),
                ImportRoot import => this.ProcessImportRoot(import),
                _ => throw new ArgumentOutOfRangeException(nameof(importItem))
            };
        }

        private Result<IReadOnlyList<ResolvedImportItem>> ProcessImportRoot(ImportRoot importItem)
        {
            throw new NotImplementedException();
        }

        private Result<IReadOnlyList<ResolvedImportItem>> ProcessImportPathItem(ImportPathItem importItem)
        {
            var result = this.ProcessImportPath(importItem.ChildItem);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var importPaths = new List<ResolvedImportItem>();

            var childPaths = result.Value;

            foreach (var path in childPaths)
            {
                var resolvedItem = new ResolvedImportPathItem(path, importItem.PathIdentifier);

                importPaths.Add(resolvedItem);
            }

            return Result.FromValue<IReadOnlyList<ResolvedImportItem>>(importPaths);
        }

        private Result<IReadOnlyList<ResolvedImportItem>> ProcessImportIdentifierAlias(ImportIdentifierAlias importItem)
        {
            var importPaths = new List<ResolvedImportItem>();

            var resolvedItem = new ResolvedImportIdentifierAlias(importItem.Identifier, importItem.AliasIdentifier);

            importPaths.Add(resolvedItem);

            return Result.FromValue<IReadOnlyList<ResolvedImportItem>>(importPaths);
        }

        private Result<IReadOnlyList<ResolvedImportItem>> ProcessImportIdentifier(ImportIdentifier importItem)
        {
            var importPaths = new List<ResolvedImportItem>();

            var resolvedItem = new ResolvedImportIdentifierAlias(importItem.Identifier, importItem.Identifier);

            importPaths.Add(resolvedItem);

            return Result.FromValue<IReadOnlyList<ResolvedImportItem>>(importPaths);
        }

        private Result<IReadOnlyList<ResolvedImportItem>> ProcessImportGroup(ImportGroup importItem)
        {
            var importPaths = new List<ResolvedImportItem>();

            foreach (var childItem in importItem.ChildItems)
            {
                var result = this.ProcessImportPath(childItem);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                importPaths.AddRange(result.Value);
            }

            return Result.FromValue<IReadOnlyList<ResolvedImportItem>>(importPaths);
        }
    }
}
