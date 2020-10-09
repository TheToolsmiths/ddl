using System;
using System.Collections.Generic;
using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Models.Package.Index;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.TypeResolver
{
    internal class DdlContentUnitCollectionTypeResolver : IDdlContentUnitCollectionTypeResolver
    {
        private readonly DdlContentUnitTypeResolver typeResolver;

        public DdlContentUnitCollectionTypeResolver(DdlContentUnitTypeResolver typeResolver)
        {
            this.typeResolver = typeResolver;
        }

        public Result<IReadOnlyList<ContentUnit>> ResolveCollection(
            IReadOnlyList<ContentUnit> contentUnits,
            PackageTypeIndex packageTypeIndex)
        {
            var indexedContentUnits = new List<ContentUnit>();

            foreach (var contentUnit in contentUnits)
            {
                var result = this.typeResolver.ResolveTypes(contentUnit, packageTypeIndex);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                indexedContentUnits.Add(result.Value);
            }

            return Result.FromValue<IReadOnlyList<ContentUnit>>(indexedContentUnits);
        }
    }
}
