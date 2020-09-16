using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Parser.TypeIndexer.ContentUnits;
using TheToolsmiths.Ddl.Parser.TypeIndexer.Packages;
using TheToolsmiths.Ddl.Parser.TypeIndexer.TypeReferences;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.TypeIndexer
{
    internal class DdlContentUnitCollectionIndexer : IDdlContentUnitCollectionIndexer
    {
        private readonly DdlContentUnitIndexer contentUnitIndexer;

        public DdlContentUnitCollectionIndexer(DdlContentUnitIndexer contentUnitIndexer)
        {
            this.contentUnitIndexer = contentUnitIndexer;
        }

        public Result<TypeReferenceIndex> IndexCollection(IEnumerable<ContentUnit> contentUnits)
        {
            var indexedTypes = new List<ContentUnitIndexedTypes>();

            foreach (var contentUnit in contentUnits)
            {
                var result = this.contentUnitIndexer.Index(contentUnit);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                indexedTypes.Add(result.Value);
            }

            var packageIndexedTypes = PackageIndexedTypesBuilder.Build(indexedTypes);
            
            var typeReferenceIndex = TypeReferenceIndexBuilder.CreateFromPackage(packageIndexedTypes);

            return Result.FromValue(typeReferenceIndex);
        }
    }
}
