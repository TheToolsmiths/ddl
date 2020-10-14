using System;
using System.Collections.Generic;
using System.Linq;
using TheToolsmiths.Ddl.Models.Ast.ImportStatements;
using TheToolsmiths.Ddl.Models.Build.ImportPaths;
using TheToolsmiths.Ddl.Parser.Build.Contexts;
using TheToolsmiths.Ddl.Parser.Build.Results;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Build.Implementations
{
    public class ImportStatementBuilder : IRootItemBuilder<ImportAstStatement>
    {
        public RootItemBuildResult BuildItem(IRootItemBuildContext itemContext, ImportAstStatement item)
        {
            var builder = new RootItemResultBuilder();

            ImportRoot rootItem = item.RootItem;

            var context = new BuildContext(builder) { IsRoot = rootItem.IsRoot };

            var result = this.ProcessImportPath(context, rootItem.ChildItem);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            return builder.CreateSuccessResult();
        }

        private Result ProcessImportPath(BuildContext context, ImportItem importItem)
        {
            return importItem switch
            {
                ImportGroup import => this.ProcessImportGroup(context, import),
                ImportIdentifier import => this.ProcessImportIdentifier(context, import),
                ImportIdentifierAlias import => this.ProcessImportIdentifierAlias(context, import),
                ImportPathItem import => this.ProcessImportPathItem(context, import),
                _ => throw new ArgumentOutOfRangeException(nameof(importItem))
            };
        }

        private Result ProcessImportPathItem(BuildContext context, ImportPathItem importItem)
        {
            context.IdentifierStack.Push(importItem.PathIdentifier.Text);

            var result = this.ProcessImportPath(context, importItem.ChildItem);

            context.IdentifierStack.Pop();

            return result;
        }

        private Result ProcessImportIdentifierAlias(BuildContext context, ImportIdentifierAlias importItem)
        {
            context.IdentifierStack.Push(importItem.Identifier.Text);

            context.CreateAndAddImportPathWithAlias(importItem.AliasIdentifier.Text);

            context.IdentifierStack.Pop();

            return Result.Success;
        }

        private Result ProcessImportIdentifier(BuildContext context, ImportIdentifier importItem)
        {
            context.IdentifierStack.Push(importItem.Identifier.Text);

            context.CreateAndAddImportPath();

            context.IdentifierStack.Pop();

            return Result.Success;
        }

        private Result ProcessImportGroup(BuildContext context, ImportGroup importItem)
        {
            foreach (var childItem in importItem.ChildItems)
            {
                var result = this.ProcessImportPath(context, childItem);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            return Result.Success;
        }

        private class BuildContext
        {
            private readonly RootItemResultBuilder builder;

            public BuildContext(RootItemResultBuilder builder)
            {
                this.builder = builder;
            }

            public bool IsRoot { get; set; }

            public Stack<string> IdentifierStack { get; } = new Stack<string>();

            public void CreateAndAddImportPath()
            {
                var path = this.IsRoot
                    ? ImportPath.CreateRooted(this.IdentifierStack.Reverse().ToList())
                    : ImportPath.CreateNonRooted(this.IdentifierStack.Reverse().ToList());

                var statement = ImportStatement.Create(path);

                this.builder.Items.Add(statement);
            }

            public void CreateAndAddImportPathWithAlias(string alias)
            {
                var path = this.IsRoot
                    ? ImportPath.CreateRooted(this.IdentifierStack.ToList())
                    : ImportPath.CreateNonRooted(this.IdentifierStack.ToList());

                var statement = ImportStatement.CreateWithAlias(path, alias);

                this.builder.Items.Add(statement);
            }
        }
    }
}
