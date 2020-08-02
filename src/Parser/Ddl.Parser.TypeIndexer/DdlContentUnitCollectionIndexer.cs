using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer
{
    internal class DdlContentUnitCollectionIndexer : IDdlContentUnitCollectionIndexer
    {
        private readonly DdlContentUnitIndexer contentUnitBuilder;

        public DdlContentUnitCollectionIndexer(DdlContentUnitIndexer contentUnitBuilder)
        {
            this.contentUnitBuilder = contentUnitBuilder;
        }

        public Result<PackageIndexedTypes> IndexCollection(IEnumerable<ContentUnit> astContentUnits)
        {
            var indexedTypes = new List<ContentUnitIndexedTypes>();

            foreach (var contentUnit in astContentUnits)
            {
                var result = this.contentUnitBuilder.Index(contentUnit);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                indexedTypes.Add(result.Value);
            }

            var packageIndexedTypes = PackageIndexedTypesBuilder.Build(indexedTypes);

            return Result.FromValue(packageIndexedTypes);
        }
    }
}
