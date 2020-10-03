using System;
using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Models.ContentUnits.Index;
using TheToolsmiths.Ddl.Models.Packages.Index;
using TheToolsmiths.Ddl.Models.Types.Index;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer
{
    internal class DdlPackageIndexer : IDdlPackageIndexer
    {
        private readonly DdlContentUnitNamespaceIndexer namespaceIndexer;
        private readonly DdlContentUnitTypeIndexer typeIndexer;

        public DdlPackageIndexer(DdlContentUnitTypeIndexer typeIndexer, DdlContentUnitNamespaceIndexer namespaceIndexer)
        {
            this.typeIndexer = typeIndexer;
            this.namespaceIndexer = namespaceIndexer;
        }

        public Result<PackageTypeIndex> IndexCollection(IReadOnlyList<ContentUnit> contentUnits)
        {
            ContentUnitNamespaceIndex namespaceIndex;
            {
                var result = this.namespaceIndexer.IndexContentUnits(contentUnits);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                namespaceIndex = result.Value;
            }

            TypeIndex typeIndex;
            {
                var result = this.typeIndexer.IndexContentUnits(namespaceIndex, contentUnits);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                typeIndex = result.Value;
            }

            var packageIndex = new PackageTypeIndex(typeIndex, namespaceIndex);

            return Result.FromValue(packageIndex);
        }
    }
}
