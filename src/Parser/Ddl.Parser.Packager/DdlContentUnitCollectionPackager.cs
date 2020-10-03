using System;
using System.Collections.Generic;

using TheToolsmiths.Ddl.Models.ContentUnits;
using TheToolsmiths.Ddl.Models.ContentUnits.Packages;
using TheToolsmiths.Ddl.Models.Packages.Index;
using TheToolsmiths.Ddl.Results;

namespace TheToolsmiths.Ddl.Parser.Packager
{
    internal class DdlContentUnitCollectionPackager : IDdlContentUnitCollectionPackager
    {
        private readonly DdlContentUnitPackager contentUnitPackager;

        public DdlContentUnitCollectionPackager(DdlContentUnitPackager contentUnitPackager)
        {
            this.contentUnitPackager = contentUnitPackager;
        }

        public Result<object> ResolveCollection(IReadOnlyList<ContentUnit> contentUnits, PackageTypeIndex packageTypeIndex)
        {
            var packedContentUnits = new List<PackagedContentUnit>();

            foreach (var contentUnit in contentUnits)
            {
                var result = this.contentUnitPackager.Pack(contentUnit, packageTypeIndex);

                if (result.IsError)
                {
                    throw new NotImplementedException();
                }

                packedContentUnits.Add(result.Value);
            }

            throw new NotImplementedException();
        }
    }
}
