using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.Build.ContentUnits;
using TheToolsmiths.Ddl.Models.Build.Indexing;
using TheToolsmiths.Ddl.Models.Build.Indexing.ContentUnits;
using TheToolsmiths.Ddl.Parser.TypeIndexer.ContentUnits;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Packages;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Types;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer
{
    internal class DdlContentUnitTypeIndexer
    {
        private readonly TypeIndexer typeIndexer;

        public DdlContentUnitTypeIndexer(TypeIndexer typeIndexer)
        {
            this.typeIndexer = typeIndexer;
        }

        public Result<TypeIndex> IndexContentUnits(
            ContentUnitNamespaceIndex namespaceIndex,
            IReadOnlyList<ContentUnit> contentUnits)
        {
            // TODO: Reimplement in a way that doesnt need two passes

            var indexedTypes = new List<ContentUnitIndexedTypes>();

            foreach (var contentUnit in contentUnits)
            {
                var result = this.Index(namespaceIndex, contentUnit);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                indexedTypes.Add(result.Value);
            }

            var packageIndexedTypes = PackageIndexedTypesBuilder.Build(indexedTypes);

            var typeIndex = TypeIndexBuilderHelper.CreateFromPackage(packageIndexedTypes);

            return Result.FromValue(typeIndex);
        }

        private Result<ContentUnitIndexedTypes> Index(ContentUnitNamespaceIndex namespaceIndex, ContentUnit contentUnit)
        {
            if (namespaceIndex.TryGetContentUnitNameSpace(contentUnit.Id, out var namespacePath) == false)
            {
                throw new NotImplementedException();
            }

            var context = new TypeIndexingContext(namespacePath);

            var result = this.typeIndexer.IndexContentUnitTypes(context, contentUnit.RootScope);

            if (result.IsError)
            {
                throw new NotImplementedException();
            }

            var indexedTypes = ContentUnitIndexedTypesBuilder.BuildFromList(
                contentUnit.Id,
                namespacePath,
                context.IndexedTypes);

            return Result.FromValue(indexedTypes);
        }
    }
}
