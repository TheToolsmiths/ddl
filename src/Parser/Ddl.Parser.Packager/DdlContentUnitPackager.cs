using System;
using TheToolsmiths.Ddl.Models.Build.Indexing;
using TheToolsmiths.Ddl.Models.Compiled.ContentUnits;
using TheToolsmiths.Ddl.Models.Compiled.Items;
using TheToolsmiths.Ddl.Models.Compiled.Scopes;
using TheToolsmiths.Ddl.Parser.Packager.ContentUnits;
using TheToolsmiths.Ddl.Parser.Packager.ContentUnits.Builders;
using TheToolsmiths.Ddl.Parser.Packager.ContentUnits.Items;
using TheToolsmiths.Ddl.Parser.Packager.Contexts;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Packager
{
    internal class DdlContentUnitPackager
    {
        public Result<PackageContentUnit> Pack(CompiledContentUnit contentUnit, ContentUnitsTypeIndex packageTypeIndex)
        {
            if (packageTypeIndex.TryGetContentUnitNamespace(contentUnit.Id, out var indexedNamespace) == false)
            {
                throw new NotImplementedException();
            }

            var namespacePath = indexedNamespace.NamespacePath;

            var rootScopeBuilder = ContentUnitPackageRootBuilder.CreateRoot();

            var namespaceBuilder = rootScopeBuilder.GetNamespaceBuilder(namespacePath);

            var context = ContentUnitPackagerContext.Create(namespaceBuilder);

            {
                var rootScopeContent = contentUnit.RootScope.Content;

                var result = this.PackageScopeContent(context, rootScopeContent);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            var items = rootScopeBuilder.BuildItemsCollection();

            var rootContent = rootScopeBuilder.BuildRootContent();

            var packagedContentUnit = new PackageContentUnit(contentUnit.Id, contentUnit.Info, namespacePath, items, rootContent);

            return Result.FromValue(packagedContentUnit);
        }

        private Result PackageScopeContent(ContentUnitPackagerContext context, CompiledScopeContent content)
        {
            foreach (var scope in content.Scopes)
            {
                var result = this.PackageScope(context, scope);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            foreach (var item in content.Items)
            {
                var result = this.PackageItem(context, item);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            return Result.Success;
        }

        private Result PackageScope(ContentUnitPackagerContext context, ICompiledScope scope)
        {
            var scopeContext = context.CreateScopeContext();

            var result = this.PackageScopeContent(scopeContext, scope.Content);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            return Result.Success;
        }

        private Result PackageItem(ContentUnitPackagerContext context, ICompiledItem item)
        {
            context.AddItem(new PackageContentUnitItem(item.ItemId, item.ItemType, item));

            return Result.Success;
        }
    }
}
