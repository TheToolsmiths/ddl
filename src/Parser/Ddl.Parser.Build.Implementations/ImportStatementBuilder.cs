using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.ImportPaths;
using TheToolsmiths.Ddl.Parser.Ast.Models.Imports;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Parser.Build.Results;

namespace TheToolsmiths.Ddl.Parser.Build.Implementations
{
    public class ImportStatementBuilder : IRootItemBuilder<ImportAstStatement>
    {
        public RootItemBuildResult BuildItem(IRootItemBuildContext itemContext, ImportAstStatement item)
        {
            var context = new RootItemBuilder();

            var result = this.CreateImportList(context, item.RootItem);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            throw new NotImplementedException();

            //return context.CreateSuccessResult();
        }

        private Result CreateImportList(
            RootItemBuilder context,
            Ast.Models.Imports.ImportItem rootItem)
        {
            Result<IReadOnlyList<ImportItem>> result;
            bool isRoot;
            if (rootItem is Ast.Models.Imports.ImportRoot importRootItem)
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

            var importPaths = new List<ImportStatement>();

            foreach (var path in childrenPaths)
            {
                throw new NotImplementedException();

                //var resolvedRoot = isRoot
                //    ? ImportPath.CreateRooted(path)
                //    : ImportPath.CreateNonRooted(path);

                //string aliasIdentifier = ImportRootHelper.GetAliasIdentifier(resolvedRoot);
                //var resolvedItem = new ImportStatement(resolvedRoot, aliasIdentifier);

                //importPaths.Add(resolvedItem);
            }

            throw new NotImplementedException();

            //context.ResolvedImportPaths.AddRange(importPaths);

            return Result.Success;
        }

        private Result<IReadOnlyList<ImportItem>> ProcessImportPath(Ast.Models.Imports.ImportItem importItem)
        {
            return importItem switch
            {
                ImportGroup import => this.ProcessImportGroup(import),
                ImportIdentifier import => this.ProcessImportIdentifier(import),
                ImportIdentifierAlias import => this.ProcessImportIdentifierAlias(import),
                ImportPathItem import => this.ProcessImportPathItem(import),
                Ast.Models.Imports.ImportRoot import => this.ProcessImportRoot(import),
                _ => throw new ArgumentOutOfRangeException(nameof(importItem))
            };
        }

        private Result<IReadOnlyList<ImportItem>> ProcessImportRoot(Ast.Models.Imports.ImportRoot importItem)
        {
            throw new NotImplementedException();
        }

        private Result<IReadOnlyList<ImportItem>> ProcessImportPathItem(ImportPathItem importItem)
        {
            var result = this.ProcessImportPath(importItem.ChildItem);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var importPaths = new List<ImportItem>();

            var childPaths = result.Value;

            throw new NotImplementedException();

            //foreach (var path in childPaths)
            //{
            //    var resolvedItem = new PathItem(path, importItem.PathIdentifier.Text);

            //    importPaths.Add(resolvedItem);
            //}

            //return Result.FromValue<IReadOnlyList<ImportItem>>(importPaths);
        }

        private Result<IReadOnlyList<ImportItem>> ProcessImportIdentifierAlias(ImportIdentifierAlias importItem)
        {
            var importPaths = new List<ImportItem>();

            throw new NotImplementedException();

            //var resolvedItem = new IdentifierAlias(importItem.Identifier.Text, importItem.AliasIdentifier.Text);

            //importPaths.Add(resolvedItem);

            //return Result.FromValue<IReadOnlyList<ImportItem>>(importPaths);
        }

        private Result<IReadOnlyList<ImportItem>> ProcessImportIdentifier(ImportIdentifier importItem)
        {
            throw new NotImplementedException();

            //var importPaths = new List<ImportItem>();

            //var resolvedItem = new IdentifierAlias(importItem.Identifier.Text, importItem.Identifier.Text);

            //importPaths.Add(resolvedItem);

            //return Result.FromValue<IReadOnlyList<ImportItem>>(importPaths);
        }

        private Result<IReadOnlyList<ImportItem>> ProcessImportGroup(ImportGroup importItem)
        {
            var importPaths = new List<ImportItem>();

            foreach (var childItem in importItem.ChildItems)
            {
                var result = this.ProcessImportPath(childItem);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                importPaths.AddRange(result.Value);
            }

            return Result.FromValue<IReadOnlyList<ImportItem>>(importPaths);
        }
    }
}
