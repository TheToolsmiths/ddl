using System;
using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.Package;
using TheToolsmiths.Ddl.Models.Package.Items;
using TheToolsmiths.Ddl.Parser.Packager.Builders;
using TheToolsmiths.Ddl.Parser.Packager.ContentUnits;
using TheToolsmiths.Ddl.Parser.Packager.Contexts;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Packager
{
    internal class DdlPackager
    {
        public Result<Package> PackageContentUnits(IReadOnlyList<PackageContentUnit> contentUnits)
        {
            var itemsBuilder = new PackageItemsBuilder();

            var rootBuilder = PackageRootBuilder.CreateRoot(itemsBuilder);

            foreach (var contentUnit in contentUnits)
            {
                var result = this.PackageContentUnit(rootBuilder, itemsBuilder, contentUnit);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            var items = itemsBuilder.Build();
            var rootContent = rootBuilder.BuildRootContent();

            var package = new Package(items, rootContent);

            return Result.FromValue(package);
        }

        private Result PackageContentUnit(
            PackageRootBuilder rootBuilder,
            PackageItemsBuilder itemsBuilder,
            PackageContentUnit contentUnit)
        {
            this.PackageItems(itemsBuilder, contentUnit.Items);

            {
                var context = PackagerNamespaceContext.Create(rootBuilder);

                var result = this.PackageNamespace(context, contentUnit.RootContent.RootNamespace);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            return Result.Success;
        }

        private void PackageItems(PackageItemsBuilder itemsBuilder, PackageContentUnitItemsCollection items)
        {
            foreach (var item in items.Items)
            {
                var packageItem = new PackageItem(item.ItemId, item.ItemType, item.Item);

                itemsBuilder.AddItem(packageItem);
            }
        }

        private Result PackageNamespace(
            PackagerNamespaceContext context,
            PackageContentUnitNamespace packageNamespace)
        {
            var content = packageNamespace.ScopeContent;

            foreach (var childNamespace in content.Namespaces)
            {
                var namespaceContext = context.CreateNamespaceContext(childNamespace.NamespacePath);

                var result = this.PackageNamespace(namespaceContext, childNamespace);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            foreach (var scope in content.Scopes)
            {
                var scopeContext = context.CreateScopeContext();

                var result = this.PackageScope(scopeContext, scope);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            {
                foreach (var item in content.Items)
                {
                    context.AddItem(item);
                }
            }

            return Result.Success;
        }

        private Result PackageScope(PackagerScopeContext context, PackageContentUnitScope packageScope)
        {
            var content = packageScope.ScopeContent;

            foreach (var scope in content.Scopes)
            {
                var scopeContext = context.CreateScopeContext();

                var result = this.PackageScope(scopeContext, scope);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }
            }

            {
                foreach (var item in content.Items)
                {
                    context.AddItem(item);
                }
            }

            return Result.Success;
        }
    }
}
